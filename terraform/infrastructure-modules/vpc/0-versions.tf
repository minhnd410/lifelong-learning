terraform {
  required_version = ">= 1.6"

  # Constraints for AWS provider
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.20.0"
    }
  }
}