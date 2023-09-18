resource "aws_codepipeline" "this" {
  name     = "library_api_pipeline"
  role_arn = aws_iam_role.codepipeline_role.arn
  artifact_store {
    location = aws_s3_bucket.this.bucket
    type     = "S3"
  }
  stage {
    name = "Source"
    action {
      name             = "Source"
      category         = "Source"
      owner            = "ThirdParty"
      provider         = "GitHub"
      version          = "1"
      output_artifacts = ["source_output"]
      configuration = {
        Owner      = var.github_repo_owner
        Repo       = var.github_repo_name
        Branch     = var.github_branch
        OAuthToken = var.github_oauth_token
      }
    }
  }
  stage {
    name = "Build"
    action {
      name             = "Build"
      category         = "Build"
      owner            = "AWS"
      provider         = "CodeBuild"
      input_artifacts  = ["source_output"]
      output_artifacts = ["build_output"]
      version          = "1"
      configuration = {
        ProjectName = aws_codebuild_project.this.name
      }
    }
  }
}
resource "aws_s3_bucket" "this" {
  bucket = "library-api-codepipeline-bucket"
}
resource "aws_s3_bucket_acl" "this" {
  bucket     = aws_s3_bucket.this.id
  acl        = "private"
  depends_on = [aws_s3_bucket_ownership_controls.this]
}
resource "aws_s3_bucket_ownership_controls" "this" {
  bucket = aws_s3_bucket.this.id
  rule {
    object_ownership = "ObjectWriter"
  }
}
resource "aws_iam_role" "codepipeline_role" {
  name               = "library_api_codepipeline_role"
  assume_role_policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "TrustPolicyStatementThatAllowsEC2ServiceToAssumeTheAttachedRole",
      "Effect": "Allow",
      "Principal": {
        "Service": "codepipeline.amazonaws.com"
      },
      "Action": "sts:AssumeRole"
    }
  ]
}
EOF
}
resource "aws_iam_role_policy" "codepipeline_policy" {
  name   = "library_api_codepipeline_policy"
  role   = aws_iam_role.codepipeline_role.id
  policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect":"Allow",
      "Action": [
        "s3:GetObject",
        "s3:GetObjectVersion",
        "s3:GetBucketVersioning",
        "s3:PutObjectAcl",
        "s3:PutObject",
        "iam:GetRole",
        "iam:PassRole"
      ],
      "Resource": [
        "${aws_s3_bucket.this.arn}",
        "${aws_s3_bucket.this.arn}/*",
        "*"
      ]
    },
    {
      "Effect": "Allow",
      "Action": [
        "codebuild:BatchGetBuilds",
        "codebuild:StartBuild"
      ],
      "Resource": "*"
    },
    {
      "Effect": "Allow",
      "Action": [
        "cloudformation:DescribeStacks",
        "kms:GenerateDataKey",
        "iam:GetRole",
        "iam:PassRole"
      ],
      "Resource": "*"
    }
  ]
}
EOF
}
resource "aws_codebuild_project" "this" {
  name          = "library_api_codebuild_project"
  description   = "Builds a docker image and pushes it to ECR"
  service_role  = aws_iam_role.codebuild_role.arn
  build_timeout = "5"
  artifacts {
    type = "CODEPIPELINE"
  }
  environment {
    compute_type    = "BUILD_GENERAL1_SMALL"
    image           = "aws/codebuild/standard:2.0"
    type            = "LINUX_CONTAINER"
    privileged_mode = true
    environment_variable {
      name  = "AWS_ACCOUNT_ID"
      value = data.aws_caller_identity.current.account_id
    }
    environment_variable {
      name  = "AWS_DEFAULT_REGION"
      value = data.aws_region.current.name
    }
    environment_variable {
      name  = "IMAGE_REPO_NAME"
      value = var.image_repo_name
    }
    environment_variable {
      name  = "PROJECT_NAME"
      value = var.project_name
    }
    environment_variable {
      name  = "IMAGE_TAG"
      value = var.image_tag
    }
    environment_variable {
      name  = "ECS_CLUSTER_NAME"
      value = aws_ecs_cluster.this.name
    }
    environment_variable {
      name  = "ECS_SERVICE_NAME"
      value = aws_ecs_service.this.name
    }
    environment_variable {
      name  = "ECS_TASK_DEFINITION"
      value = aws_ecs_task_definition.this.family
    }
  }
  source {
    type      = "CODEPIPELINE"
    buildspec = "buildspec.yml"

  }
}
resource "aws_iam_role" "codebuild_role" {
  name               = "library_api_codebuild_role"
  assume_role_policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Action": "sts:AssumeRole",
      "Principal": {
        "Service": "codebuild.amazonaws.com"
      },
      "Effect": "Allow",
      "Sid": "TrustPolicyStatementThatAllowsEC2ServiceToAssumeTheAttachedRole"
    }
  ]
}
EOF
}
resource "aws_iam_role_policy" "codebuild_policy" {
  name   = "library_api_codebuild_policy"
  role   = aws_iam_role.codebuild_role.id
  policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Action": [
        "logs:CreateLogGroup",
        "logs:CreateLogStream",
        "logs:PutLogEvents"
      ],
      "Resource": "arn:aws:logs:*:*:*",
      "Effect": "Allow"
    },
    {
      "Action": [
        "s3:GetObject",
        "s3:GetObjectVersion",
        "s3:GetBucketVersioning"
      ],
      "Resource": [
        "arn:aws:s3:::${aws_s3_bucket.this.bucket}",
        "arn:aws:s3:::${aws_s3_bucket.this.bucket}/*"
      ],
      "Effect": "Allow"
    },
    {
      "Action": [
        "ecr:BatchCheckLayerAvailability",
        "ecr:CompleteLayerUpload",
        "ecr:GetAuthorizationToken",
        "ecr:InitiateLayerUpload",
        "ecr:PutImage",
        "ecr:UploadLayerPart"
      ],
      "Resource": [
        "*"
      ],
        "Effect": "Allow"
    },
    {
      "Action": [
        "ecs:UpdateService",
        "iam:GetRole",
        "iam:PassRole"
      ],
      "Resource": [
        "*"
      ],
        "Effect": "Allow"
    }
  ]
}
EOF
}
