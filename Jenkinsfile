pipeline {
	agent any
	stages {
		stage('Build') {
			steps {
				script {
					def files = sh(script: 'find ./Assets/scripts/ -name "*.cs"', returnStdout: true).split('\n')

					for(file in files) {
						if(file != "\n") {
							sh "echo \"public class MainClass{public static void Main(string[] args){}}\" >> ${file}"
							sh "mcs -warn:4 -r:./Assets/natives/UnityEngine.dll ${file}"
							sh "sed -i '$d' ${file}'
						}
					}
				}
			}
		}
	}
}
 
