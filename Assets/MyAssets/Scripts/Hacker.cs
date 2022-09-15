using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	int level;
	enum Screen {MainMenu, Password, Win};
	Screen CurrentScreen;
	// Use this for initialization
	void Start () {
		StartMenu ();
	}
	
	void StartMenu(){
		Terminal.ClearScreen ();
		Terminal.WriteLine ("Shwetank Singh");
		Terminal.WriteLine ("Welcome To Dark Web Terminal !!");
		Terminal.WriteLine ("1. Level 01");
		Terminal.WriteLine ("2. Level 02");

	}

	void OnUserInput(string Input){
		if (Input == "menu") {
			StartMenu ();
		} else if (Input == "1") {
			level = 1;
			StartGame ();
		} else {
			Terminal.WriteLine ("enter a valid input");
		}
	}

	void StartGame(){
		CurrentScreen = Screen.Password;
		Terminal.WriteLine ("Welcome To Level" + level);

	}




}
