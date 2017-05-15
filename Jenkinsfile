pipeline {
	agent any

	stages {
		stage('Build') {
			steps {
				MAINSCRUCT="public class MainClass{public static void Main(string[] args){}}";
				NATIVES="-r:./Assets/natives/UnityEngine.dll";
				WARNING="-warn:4";
				FILES=$(find ./Assets/scripts/ -name "*.cs");

				printf "####################\n";
				printf "#  BUILDING START  #\n";
				printf "####################\n";
				printf "\n";

				for FILE in $FILES
				do
					printf "=============================================\n";
					printf "Building script %s\n" $FILE;
					printf "=============================================\n";

					echo $MAINSCRUCT >> $FILE;
					COMPILE=$(mcs $NATIVES $WARNING $FILE);
					if [ -z "$COMPILE" ]
					then
						printf ">>> Successful building ! <<<\n";
						rm ./Assets/scripts/*.exe;
					else
						printf "[ERROR] Building fail on %s :\n" $FILE;
						echo "Report :" $COMPILE;
					fi
					sed -i '$d' $FILE;
					printf "\n";
				done

			}
		}
	}
}
