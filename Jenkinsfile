
pipeline{
    agent {label 'master'}
    parameters{
        string(
            name: "GIT_HTTPS_PATH",
            defaultValue: "https://github.com/tavisca-dshrivastav/SampleWebApi.git",
            description: "GIT HTTPS PATH"
        )
        string(
            name: "SOLUTION_PATH",
            defaultValue: "WebApi.sln",
            description: "SOLUTION_PATH"
        )
        string(
            name: "TEST_SOLUTION_PATH",
            defaultValue: "WebApi.Test/WebApi.Test.csproj",
            description: "TEST SOLUTION PATH"
        )
        
        string(
            name: "PROJECT_PATH",
            defaultValue: "WebApi/WebApi.csproj",
            description: "TEST SOLUTION PATH"
        )
        choice(
            name: "RELEASE_ENVIRONMENT",
            choices: ["Build","Test", "Publish"],
            description: "Tick what you want to do"
        )
    }
    stages{
        stage('Build'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Build" || params.RELEASE_ENVIRONMENT == "Test" || params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps{
                powershell '''
                    echo '====================Build Project Start ================'
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json
                    echo '=====================Build Project Completed============'
                    echo '====================Build Project Start ================'
                    dotnet build ${SOLUTION_PATH} -p:Configuration=release -v:n
                    echo '=====================Build Project Completed============'
                '''
            }
        }
        stage('Test'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Test" || params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps{
                powershell '''
                    echo '====================Build Project Start ================'
                    dotnet test ${TEST_SOLUTION_PATH}
                    echo '=====================Build Project Completed============'
                '''
            }
        }
        stage('Publish'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps{
                powershell '''
                    echo '====================Build Project Start ================'
                    dotnet publish ${PROJECT_PATH}
                    echo '=====================Build Project Completed============'
                '''
            }
        }

    }
    post{
        always{
           archiveArtifacts artifact : 'WebApi/bin/Release/netcoreapp2.2/*'
        }
    }
}
