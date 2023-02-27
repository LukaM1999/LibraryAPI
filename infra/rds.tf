# Create an RDS SQL Server instance
resource "aws_db_instance" "this" {
  allocated_storage    = 20
  engine               = "sqlserver-ex"
  engine_version       = "15.00.4236.7.v1"
  instance_class       = "db.t3.small"
  license_model        = "license-included"
  skip_final_snapshot  = true
  username             = "my_db_username"
  password             = "my_db_password"
  db_subnet_group_name = "${aws_db_subnet_group.this.name}"
  backup_retention_period = 0
  vpc_security_group_ids = [aws_security_group.this.id]
  publicly_accessible = true

  tags = {
    Name = "my-db-instance"
  }
}

# Create a DB subnet group
resource "aws_db_subnet_group" "this" {
  name = "my-db-subnet-group"
  subnet_ids = data.aws_subnet_ids.this.ids

  tags = {
    Name = "my-db-subnet-group"
  }
}