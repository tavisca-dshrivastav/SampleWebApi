
pipeline{
    agent { label 'master' }
    stages{
        stage('build'){
            steps{
                sh'git clone "https://github.com/tavisca-dshrivastav/SampleWebApi.git"'
                sh '
                echo "====================Build Project Start ================"
                    dotnet restore WebApi.sln --source https://api.nuget.org/v3/index.json
                echo "=====================Build Project Completed============"
                '
            }
        }
    }
}
