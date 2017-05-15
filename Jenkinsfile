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
					$FILES.each {
						echo $MAINSCRUCT >> $FILE;
						${params.Command}="mcs $NATIVES $WARNING $FILE;";
						COMPILE=${params.Command}.execute();
						sh 'sed -i \'$d\' $FILE';
					}
				}
			}
		}
	}
}
 
