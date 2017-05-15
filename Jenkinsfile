#!/bin/bash

pipeline {
	agent any

	stages {
		stage('Build') {
			steps {
				MAINSCRUCT="public class MainClass{public static void Main(string[] args){}}";
				NATIVES="-r:./Assets/natives/UnityEngine.dll";
				WARNING="-warn:4";
				command="find ./Assets/scripts/ -name \"*.cs\";";
				FILES=command.execute();

				printf "####################\n";
				printf "#  BUILDING START  #\n";
				printf "####################\n";
				printf "\n";

				$FILES.each {
					printf "=============================================\n";
					printf "Building script %s\n" $FILE;
					printf "=============================================\n";

					echo $MAINSCRUCT >> $FILE;
					command="mcs $NATIVES $WARNING $FILE;";
					COMPILE=command.execute();
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
				}
			}
		}
	}
}
