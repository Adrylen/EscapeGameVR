pipeline {
	environment {
		f = "./Assets/scripts/testScript.cs"
		testing = sh(script: 'find ./Assets/scripts/ -name "*.cs"', returnStdout: true).split('\n')
	}

	agent any
	stages {
		stage('Build') {
			steps {
				for (tester in ${testing}) {
					echo tester
				}
				sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
				sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
			}
		}
	}
}
 
