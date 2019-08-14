
pipeline{
    environment{
        $RELEASE_ENVIRONMENT = params.RELEASE_ENVIRONMENT
    }
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
        choice(
            name: "RELEASE_ENVIRONMENT",
            choices: ["Build","Test"],
            description: "Tick what you want to do"
        )
    }
    stages{
        stage('Build'){
            when{
                expression{$RELEASE_ENVIRONMENT == "Build"}
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
                expression{$RELEASE_ENVIRONMENT == "Test"}
            }
            steps{
                powershell '''
                    echo '====================Build Project Start ================'
                    dotnet test ${TEST_SOLUTION_PATH}
                    echo '=====================Build Project Completed============'
                '''
            }
        }
    }
    post{
        always{
            deleteDir()
        }
    }
}
