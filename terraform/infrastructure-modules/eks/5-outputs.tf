output "eks_name" {
    value = aws_eks_cluster.this.name
}

#   To deploy cluster autoscaler, we need to use this OpenID 
# provider ARN to establish trust between AWS IAM and the 
# Kubernetes service account
output "openid_provider_arn" {
    value = aws_iam_openid_connect_provider.this[0].arn
}