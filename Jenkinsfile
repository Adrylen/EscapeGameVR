pipeline {
	agent any
	stages {
		stage('Build') {
			steps {
				def f = "./Assets/scripts/testScript.cs"
				sh "echo 'public class MainClass{public static void Main(string[] args){}}' >> ${f}"
				sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${f}"
			}
		}
	}
}
 
