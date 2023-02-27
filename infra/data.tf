data "aws_vpc" "this" {
  default = true
}

data "aws_subnet_ids" "this" {
  vpc_id = data.aws_vpc.this.id
}

data "aws_region" "current" {}

data "aws_caller_identity" "current" {}

data "template_file" "openapi_spec" {
  template = file("openapi.yaml")
}
