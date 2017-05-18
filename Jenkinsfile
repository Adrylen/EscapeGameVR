pipeline {
	environment {
		f = "./Assets/scripts/testScript.cs"
		testing = sh(script: 'find ./Assets/scripts/ -name "*.cs"', returnStdout: true)
	}

	agent any
	stages {
		stage('Build') {
			steps {
				sh "for f in $(find ./Assets/scripts/ -name "*.cs"); do echo \"public class MainClass{public static void Main(string[] args){}}\" >> \$f; mcs -warn:4 -r:./Assets/natives/UnityEngine.dll \$f; done"
			}
		}
	}
}
 
