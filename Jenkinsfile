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
				$FILES.each {
					echo $MAINSCRUCT >> $FILE;
					command="mcs $NATIVES $WARNING $FILE;";
					COMPILE=command.execute();
					sh 'sed -i \'$d\' $FILE';
				}
			}
		}
	}
}
 
