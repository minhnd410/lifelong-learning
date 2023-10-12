# Network Address Translation (NAT) Gateway to provide internet access to private subnets
# Recommend: Manually allocating a static public IP address, might need to whitelist it with clients in the future

resource "aws_eip" "nat" {
    tags = {
        Name = "dev-nat"
    }
}

resource "aws_nat_gateway" "nat" {
    allocation_id = aws_eip.nat.id
    subnet_id = aws_subnet.public_us_east_1a.id
    
    tags = {
        Name = "dev-nat"
    }

    depends_on = [ aws_internet_gateway.igw ]
}