output "load_balancer_url" {
  value = aws_lb.this.dns_name
}

# Generated API GW endpoint URL that can be used to access the application running on a private ECS Fargate cluster.
output "apigw_endpoint" {
  value = aws_apigatewayv2_api.this.api_endpoint
  description = "API Gateway Endpoint"
}


output "db_url" {
  value = aws_db_instance.this.endpoint
}

output "db_connection_string" {
  value = "Server=${aws_db_instance.this.endpoint};Database=LibraryDB;User ID=my_db_username;Password=my_db_password"
}
