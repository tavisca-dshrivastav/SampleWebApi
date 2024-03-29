pipeline{
    agent { label 'master' }

    parameters{
   
        string(
            name: "DOCKER_USER_NAME",
            description: "Enter Docker hub Username"
        )
        string(
            name: "DOCKER_PASSWORD",
            description:  "Enter Docker hub Password"
        )
        string(
            name: "DOCKER_REPO",
            defaultValue: "api"
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
        )
        
         string(
            name: "SOLUTION_DLL_FILE",
            defaultValue: "WebApi.dll",
        )
        
        choice(
            name: "RELEASE_ENVIRONMENT",
            choices: ["Build","Deploy"],
            description: "Tick what you want to do"
        )
    }
    stages{
        stage('Build'){
            when{
                expression{params.RELEASE_ENVIRONMENT == "Build" || params.RELEASE_ENVIRONMENT == "Deploy"}
            }
            steps{
                powershell '''
                    echo '====================Restore Start ================'
                    dotnet restore ${SOLUTION_PATH} --source https://api.nuget.org/v3/index.json
                    echo '=====================Restore  Completed============'
                    echo '====================Build Start ================'
                    dotnet build ${PPOJECT_PATH} 
                    echo '=====================Build  Completed============'
                    echo '====================Build  Start ================'
                    dotnet test ${TEST_SOLUTION_PATH}
                    echo '=====================Build Completed============'
                    echo '====================Publish Start ================'
                    dotnet publish ${PROJECT_PATH}
                    echo '=====================Publish Completed============'
                    '''
            }
        }
        
        stage ('Deploy') {
            when{
                expression{params.RELEASE_ENVIRONMENT == "Deploy"}
            }
            steps {
                writeFile file: 
                        'WebApi/bin/Debug/netcoreapp2.2/publish/Dockerfile', text: '''
                        FROM mcr.microsoft.com/dotnet/core/aspnet\n
                        ENV NAME ${DOCKER_REPO}\n
                        CMD ["dotnet", "${SOLUTION_DLL_FILE}"]\n'''
                
                powershell "docker build WebApi/bin/Debug/netcoreapp2.2/publish/ --tag=${DOCKER_REPO}:${BUILD_NUMBER}"    
               // powershell "docker login -u ${DOCKER_USER_NAME} -p ${DOCKER_PASSWORD}"
                powershell "docker tag ${DOCKER_REPO}:${BUILD_NUMBER} ${DOCKER_USER_NAME}/${DOCKER_REPO}:${BUILD_NUMBER}"
                powershell "docker push ${DOCKER_USER_NAME}/${DOCKER_REPO}:${BUILD_NUMBER}"
            }
        }
    }
    post{
        always{
            deleteDir()
       }
    }
}
