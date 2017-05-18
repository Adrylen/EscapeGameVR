pipeline {
	environment {
		f = "./Assets/scripts/testScript.cs"
		list_of_files = sh(script: 'find ./Assets/scripts/ -name "*.cs"', returnStdout: true)
	}

	agent any
	stages {
		stage('Build') {
			steps {
				script {
					name = ""
					for (letter in list_of_files) {
						if(tester == "\n") {
							echo "File found : " name
							echo "OK"
							name = ""
						} else {
							name += letter
						}
					}
					sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
					sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
				}
			}
		}
	}
}
 
