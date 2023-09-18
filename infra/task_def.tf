resource "aws_ecs_task_definition" "this" {
  family                   = "library_api"
  memory                   = 512
  cpu                      = 256
  requires_compatibilities = ["FARGATE"]
  task_role_arn            = aws_iam_role.task.arn
  execution_role_arn       = aws_iam_role.task.arn
  network_mode             = "awsvpc"
  container_definitions = jsonencode(
    [{
      "name" : "my-api"
      "image" : "${data.aws_caller_identity.current.account_id}.dkr.ecr.${data.aws_region.current.name}.amazonaws.com/library_api",
      "portMappings" : [
        { containerPort = 80 }
      ],
      "environment" : [
        { name = "ASPNETCORE_ENVIRONMENT", value = "Production" },
        { name = "ConnectionStrings__ProductionConnection", value = "Server=${replace(aws_db_instance.this.endpoint, ":", ",")};Database=LibraryDB;User ID=my_db_username;Password=my_db_password" },
        { name = "JWT__ValidAudience", value = "${aws_apigatewayv2_api.this.api_endpoint}" },
        { name = "JWT__ValidIssuer", value = "${aws_lb.this.dns_name}" },
        { name = "JWT__Secret", value = "${var.jwt_secret}" }
      ],
      "logConfiguration" : {
        "logDriver" : "awslogs",
        "options" : {
          "awslogs-group" : "/ecs/my-api",
          "awslogs-region" : "${data.aws_region.current.name}",
          "awslogs-stream-prefix" : "ecs"
        }
      }
    }]
  )
  depends_on = [
    aws_cloudwatch_log_group.this
  ]
}

resource "aws_cloudwatch_log_group" "this" {
  name = "/ecs/my-api"
}
