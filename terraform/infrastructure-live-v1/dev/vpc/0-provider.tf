provider "aws" {
  region = "us-east-1"
}

terraform {
  required_version = ">= 1.6"

  # store backend config in local for testing purpose
  # TODO: change to store in S3 or DynamoDB
  backend "local" {
    path = "dev/vpc/terraform.tfstate"
  }

  # Constraints for AWS provider
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.20.0"
    }
  }
}