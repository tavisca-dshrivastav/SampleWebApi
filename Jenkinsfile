pipeline{
    agent { label 'master' }
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
            name: "DOTNETCORE_VERSION",
            defaultValue: "2.2",
            description: "Version"
        )
        string(
            name: "TEST_SOLUTION_PATH",
            defaultValue: "WebApi.Test/WebApi.Test.csproj",
            description: "TEST SOLUTION PATH"
        )
        
        string(
            name: "PROJECT_PATH",
            defaultValue: "WebApi/WebApi.csproj",
        )
         string(
            name: "DOCKERFILE",
            defaultValue: "mcr.microsoft.com/dotnet/core/aspnet",
        )
         string(
            name: "ENV_NAME",
            defaultValue: "Api",
        )
         string(
            name: "SOLUTION_DLL_FILE",
            defaultValue: "WebApi.dll",
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
                    dotnet build ${PPOJECT_PATH} 
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
        stage ('Creating Docker Image') {
            when{
                expression{params.RELEASE_ENVIRONMENT == "Publish"}
            }
            steps {
                writeFile file: 'WebApi/bin/Debug/netcoreapp2.2/publish/Dockerfile', text:'''FROM ${DOCKERFILE}\n
                                ENV NAME ${ENV_NAME}\n
                                CMD ["dotnet", "${SOLUTION_DLL_FILE}"]\n'''
                powershell '''
                    docker build WebApi/bin/Debug/netcoreapp2.2/publish/ --tag=webapi:v0.0.1
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
