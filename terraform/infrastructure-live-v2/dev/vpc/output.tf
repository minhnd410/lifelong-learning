#   optionally, we can use output variables if we want
# to display them in the console; otherwise, we can still
# use them, but the wont be printed to the console

output "vpc_id" {
  value = module.vpc.vpc_id
}

output "private_subnets_ids" {
  value = module.vpc.private_subnets_ids
}

output "public_subnets_ids" {
  value = module.vpc.public_subnets_ids
}