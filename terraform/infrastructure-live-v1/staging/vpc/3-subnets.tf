# PRIVATE SUBNET 1A
resource "aws_subnet" "private_us_east_1a" {
  vpc_id = aws_vpc.main.id
  cidr_block = "10.0.0.0/19"
  availability_zone = "us-east-1a"

  tags = {
    "Name" = "staging-private-us-east-1a"
    # indicating eks can use the subnet to create privtae load balancer
    "kubernetes.io/role/internal-elb" = "1"
    # associate this subnet with the eks, valued of "owned" or "shared"
    "kubernetes.io/cluster/staging-demo" = "owned"
  }
}

# PRIVATE SUBNET 1B
resource "aws_subnet" "private_us_east_1b" {
  vpc_id = aws_vpc.main.id
  cidr_block = "10.0.32.0/19"
  availability_zone = "us-east-1b"

  tags = {
    "Name" = "staging-private-us-east-1b"
    "kubernetes.io/role/internal-elb" = "1"
    "kubernetes.io/cluster/staging-demo" = "owned"
  }
}

# PUBLIC SUBNET 1A
resource "aws_subnet" "public_us_east_1a" {
  vpc_id = aws_vpc.main.id
  cidr_block = "10.0.64.0/19"
  availability_zone = "us-east-1a"
  # Enable auto-assign public IP on VM launch
  map_public_ip_on_launch = true

  tags = {
    "Name" = "staging-public-us-east-1a"
    # allow aks to create public load balancer
    "kubernetes.io/role/elb" = "1"
    "kubernetes.io/cluster/staging-demo" = "owned"
  }
}

# PUBLIC SUBNET 1A
resource "aws_subnet" "public_us_east_1b" {
  vpc_id = aws_vpc.main.id
  cidr_block = "10.0.96.0/19"
  availability_zone = "us-east-1b"
  map_public_ip_on_launch = true

  tags = {
    "Name" = "staging-public-us-east-1b"
    "kubernetes.io/role/elb" = "1"
    "kubernetes.io/cluster/staging-demo" = "owned"
  }
}