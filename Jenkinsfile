pipeline {
	agent any

	environment {
		f = "./Assets/scripts/testScript.cs"
	}

	stages {
		stage('Build') {
			sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
			sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
		}
	}
}
 
