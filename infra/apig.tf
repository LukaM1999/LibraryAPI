# Create the VPC Link configured with the private subnets. Security groups are kept empty here, but can be configured as required.
resource "aws_apigatewayv2_vpc_link" "this" {
  name        = "vpclink_apigw_to_alb"
  security_group_ids = []
  subnet_ids = data.aws_subnet_ids.this.ids
}

# Create the API Gateway HTTP endpoint
resource "aws_apigatewayv2_api" "this" {
  name          = "apigw_http_endpoint"
  protocol_type = "HTTP"
}

# Create the API Gateway HTTP_PROXY integration between the created API and the private load balancer via the VPC Link.
# Ensure that the 'DependsOn' attribute has the VPC Link dependency.
# This is to ensure that the VPC Link is created successfully before the integration and the API GW routes are created.
resource "aws_apigatewayv2_integration" "this" {
  api_id           = aws_apigatewayv2_api.this.id
  integration_type = "HTTP_PROXY"
  integration_uri  = aws_lb_listener.http.arn

  integration_method = "ANY"
  connection_type    = "VPC_LINK"
  connection_id      = aws_apigatewayv2_vpc_link.this.id
  payload_format_version = "1.0"
  depends_on      = [aws_apigatewayv2_vpc_link.this, 
                    aws_apigatewayv2_api.this, 
                    aws_lb_listener.http]
}

# API GW route with ANY method
resource "aws_apigatewayv2_route" "this" {
  api_id    = aws_apigatewayv2_api.this.id
  route_key = "ANY /{proxy+}"
  target = "integrations/${aws_apigatewayv2_integration.this.id}"
  depends_on  = [aws_apigatewayv2_integration.this]
}

# Set a default stage
resource "aws_apigatewayv2_stage" "this" {
  api_id = aws_apigatewayv2_api.this.id
  name   = "$default"
  auto_deploy = true
  depends_on  = [aws_apigatewayv2_api.this]
}