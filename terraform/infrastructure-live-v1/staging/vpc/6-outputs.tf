# If use as input for another Terraform code or module

output "vpc_id" {
  value = aws_vpc.main.id
}