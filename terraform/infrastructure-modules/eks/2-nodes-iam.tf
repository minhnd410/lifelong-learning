# IAM policy and IAM role for kubernetes nodes
resource "aws_iam_role" "nodes" {
    name = "${var.env}-${var.eks_name}-eks-nodes"

    assume_role_policy = jsondecode({
        Statement = [{
            Action = "sts:AssumeRole"
            Effect = "Allow"
            Principal = {
                Service = "ec2.amazonaws.com"
            }
        }]
        Version = "2012-10-17"
    })
}

resource "aws_iam_role_policy_attachment" "nodes" {
    # use for each loop to iterate over all provided policies and attach them to the nodes IAM role
    # the last policy is optional. It allow use the session manager to SSH into the nodes
    for_each = var.node_iam_policies

    policy_arn = each.value
    role = aws_iam_role.nodes.name
}