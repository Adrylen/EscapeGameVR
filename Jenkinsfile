pipeline {
	agent any
	stages {
		stage('Build') {
			steps {
				script {
					sh 'mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ./Assets/scripts/testScript.cs'
				}
			}
		}
	}
}
 
