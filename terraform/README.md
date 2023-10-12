Credit to: me@antonputra.com

https://www.youtube.com/watch?v=yduHaOj3XMg

## Structure
/infrastructure-live-v1 :: Plain Terraform code to create aws vpc in 2 env dev and staging

/infrastructure-live-v2 :: Convert to terraform module in /infrastructure-modules/vpc

/infrastructure-live-v3 :: Apply terragrunt to simplify create flow of v2 using /infrastructure-modules/vpc

/infrastructure-live-v4 :: Creation of /infrastructure-modules/eks

## Ref
- [Use multiple aws accounts with AWS CLI](https://dev.to/hmintoh/how-to-use-multiple-aws-accounts-with-the-aws-cli-3lge)
- [CIDR Calculator tools](https://www.ipaddressguide.com/cidr)
- [Install Terraform](https://developer.hashicorp.com/terraform/downloads)
- [Install Terragrunt](https://terragrunt.gruntwork.io/docs/getting-started/install/)


## [Terraform] Basic commands
- Direct to a working dir
```
cd environments-live-v1/dev/vpc 
```

- Download all required Terraform providers
- Initialize the Terraform state
    - Dir .terraform & .terraform.lock.hcl created inside vpc folder as defined
```
terraform init
```
- To initialize new .terraform dir, run (be careful)
```
terraform init -reconfigure
```

- Apply terraform
```
terraform apply
```

- Destroy terraform
```
terraform destroy
```


## [Terragrunt] Basic commands
- Init terrafrunt
```
terragrunt init
```

- Apply terraform
```
terragrunt apply
```

- Destroy terraform
```
terragrunt run-all destroy
```