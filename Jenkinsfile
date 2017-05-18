pipeline {
	environment {
		f = "./Assets/scripts/testScript.cs"
		testing = sh(script: 'ls', returnStdout: true)
	}

	agent any
	stages {
		stage('Build') {
			steps {
				sh "echo \"${testing}\""
				sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
				sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
			}
		}
	}
}
 
