pipeline {
	environment {
		f = "./Assets/scripts/testScript.cs"
		testing  = sh script: 'find ./Assets/scripts/ -name \"*.cs\"'
	}

	agent any
	stages {
		stage('Build') {
			steps {
				echo ${testing}
				sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
				sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
			}
		}
	}
}
 
