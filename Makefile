export PROJECT_NAME=LibraryAPI
export REPO_NAME=library_api
export ACCOUNT_NUMBER=$(shell aws sts get-caller-identity --query 'Account' --output text)
export AWS_DEFAULT_REGION=eu-west-2
export ECR_URL=${ACCOUNT_NUMBER}.dkr.ecr.${AWS_DEFAULT_REGION}.amazonaws.com
export ALB_URL=$(shell terraform output -json | jq -r '.load_balancer_url.value')
export APIG_URL=$(shell terraform output -json | jq -r '.apigw_endpoint.value')
export DB_URL=$(shell terraform output -json | jq -r '.db_url.value')

repo:
	aws ecr create-repository --repository-name ${REPO_NAME}

login:
	aws ecr get-login-password --region ${AWS_DEFAULT_REGION} | docker login --username AWS --password-stdin ${ECR_URL}

image:
	docker build --rm --pull -f ${PROJECT_NAME}/${PROJECT_NAME}/Dockerfile -t ${REPO_NAME} ./${PROJECT_NAME}
	docker tag ${REPO_NAME}:latest ${ECR_URL}/${REPO_NAME}:latest
	docker push ${ECR_URL}/${REPO_NAME}:latest

init:
	terraform -chdir=infra init

plan:
	terraform -chdir=infra plan

apply:
	terraform -chdir=infra apply -auto-approve

kill:
	terraform -chdir=infra destroy -auto-approve
	# aws ecr list-images --repository-name ${REPO_NAME} --query 'imageIds[*].imageDigest' --output text | while read imageId; do aws ecr batch-delete-image --repository-name ${REPO_NAME} --image-ids imageDigest=$$imageId; done
	# aws ecr delete-repository --repository-name ${REPO_NAME}