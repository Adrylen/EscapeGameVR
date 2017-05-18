pipeline {
	agent any
	stages {
		stage('Build') {
			steps {
				sh "echo \"public class MainClass{public static void Main(string[] args){}}\" >> ./Assets/scripts/testScript.sc"
				sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ./Assets/scripts/testScript.cs"
			}
		}
	}
}
 
