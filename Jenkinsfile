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
						if(letter == "\n") {
							echo "File found"
							echo name
							sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${name}"
							sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${name}"
							name = ""
						} else {
							name += letter
						}
					}
					sh "rm ./Assets/scripts/*.exe"
					sh "rm ./Assets/scripts/*.sc"
				}
			}
		}
	}
}
 
