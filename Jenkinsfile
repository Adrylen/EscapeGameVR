pipeline {
	agent any
	parameters {
		string(name: 'MainStruct', defaultValue: "public class MainClass{public static void Main(string[] args){}}")
		string(name: 'Natives', defaultValue: "-r:./Assets/natives/UnityEngine.dll")
		string(name: 'Warning', defaultValue: "-warn:4")
		string(name: 'Command', defaultValue: "find ./Assets/scripts/ -name \"*.cs\";")
	}
	stages {
		stage('Build') {
			steps {
				script {
					FILES=${params.Command}.execute();
					for (i in $FILES) {
						echo $MAINSCRUCT >> $i;
						sh 'mcs ${params.Natives} ${params.Warning} $i;';
						sh 'sed -i \'$d\' $FILE';
					}
				}
			}
		}
	}
}
 
