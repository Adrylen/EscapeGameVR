pipeline {
	environment {
		f = "./Assets/scripts/testScript.cs"
		testing = sh(script: 'find ./Assets/scripts/ -name "*.cs"', returnStdout: true)
	}

	agent any
	stages {
		stage('Build') {
			steps {
				script {
					name = ""
					for (tester in testing) {
						if(tester == "\n") {
							echo name
							echo "OK"
							name = ""
						} else {
							name += tester
						}
					}
					sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
					sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
				}
			}
		}
	}
}
 
