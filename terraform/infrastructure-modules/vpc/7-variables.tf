variable "env" {
    description = "Environment name."
    type = string
}

variable "vpc_cidr_block" {
    description = "CIDR (Classless Inter-Domain Routing) block for the VPC."
    type = string
    default = "10.0.0.0/16"
}

variable "azs" {
    description = "Availability zones to use for the subnets."
    type = list(string)
}

variable "private_subnets" {
    description = "CIDR ranges for private subnets."
    type = list(string)
}

variable "public_subnets" {
    description = "CIDR ranges for public subnets."
    type = list(string)
}

variable "private_subnets_tags" {
    description = "Private subnets tag."
    type = map(any)
}

variable "public_subnets_tags" {
    description = "Public subnets tag."
    type = map(any)
}