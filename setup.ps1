param (
	[string]$webSiteName = "Nnerdlings",
	[string]$webProjectName = "SitefinityProject",
	[string]$solutionDir = (Split-Path $MyInvocation.MyCommand.Path) 
)

. "$solutionDir\iis.ps1"

function main {
	Disable-GitSSLVerification
	Install-FeatherNodeTools
	Setup-LocalSite $webSiteName "$solutionDir\$webProjectName"
}

function Disable-GitSSLVerification {
	git config --global http.sslVerify false
}

function Install-FeatherNodeTools {
	pushd "$solutionDir\$webProjectName\ResourcePackages\Bootstrap"
	npm install --global --production windows-build-tools	
	npm install
	npm install -g grunt-cli
	grunt
	popd
}

Try { main } 
Catch { Write-Error $_.Exception }