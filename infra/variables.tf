variable "image_repo_name" {
  default = "library_api"
}
variable "project_name" {
  default = "LibraryAPI"
}
variable "image_tag" {
  default = "latest"
}
variable "github_repo_owner" {
  default = "LukaM1999"
}
variable "github_repo_name" {
  default = "LibraryAPI"
}
variable "github_branch" {
  default = "main"
}
variable "github_oauth_token" {
  type      = string
  sensitive = true
}
variable "jwt_secret" {
  type      = string
  sensitive = true
}
