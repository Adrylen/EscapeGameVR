pipeline {
	agent any
	parameters {
		string(name: 'Main', defaultValue: 'public class MainClass{public static void Main(string[] args){}}')
	}
	stages {
		stage('Build') {
			steps {
				script {
					sh "echo ${params.Main} >> ./Assets/scripts/testScript.cs"
					sh 'mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ./Assets/scripts/testScript.cs'
					sh 'sed -i \'$d\' ./Assets/scripts/testScript.cs'
				}
			}
		}
	}
}
 
