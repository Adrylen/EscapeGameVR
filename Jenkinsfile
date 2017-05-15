pipeline {
	agent any

	stages {
		stage('Build') {
			steps {
				MAINSCRUCT="public class MainClass{public static void Main(string[] args){}}";
				NATIVES="-r:./Assets/natives/UnityEngine.dll";
				WARNING="-warn:4";
				SCRIPTS=$(find ./Assets/scripts/ -name "*.cs");

				printf "####################\n";
				printf "#  BUILDING START  #\n";
				printf "####################\n";
				printf "\n";

				for SCRIPT in $SCRIPTS
				do
					printf "=============================================\n";
					printf "Building script %s\n" $SCRIPT;
					printf "=============================================\n";

					echo $MAINSCRUCT >> $SCRIPT;
					COMPILE=$(mcs $NATIVES $WARNING $SCRIPT);
					if [ -z "$COMPILE" ]
					then
						printf ">>> Successful building ! <<<\n";
						rm ./Assets/scripts/*.exe;
					else
						printf "[ERROR] Building fail on %s :\n" $SCRIPT;
						echo "Report :" $COMPILE;
					fi
					sed -i '$d' $SCRIPT;
					printf "\n";
				done

			}
		}
	}
}
