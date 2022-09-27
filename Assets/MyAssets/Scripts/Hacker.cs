using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{   
	//Game configuration data
	const string menuHint = "You may type menu at any time";
	string[] level1Passwords = {"books","aisle","shelf","password","font","borrow"};
	string[] level2Passwords = {"prisoner","handcuffes","holster","uniform","arrest"};

	//Game State
	int level;

	enum Screen {MainMenu, Password, Win};

	Screen CurrentScreen;
	//initialize the screen mode.To main Menu.
	string passward;

	void Start ()
	{
		StartMenu ();
	}

	void StartMenu ()
	{
		
		CurrentScreen = Screen.MainMenu;  //set the screen to main Menu whenever the menu is called.
		Terminal.ClearScreen ();
		Terminal.WriteLine ("Shwetank Singh");
		Terminal.WriteLine ("Welcome To Dark Web Terminal !!");
		Terminal.WriteLine ("1. Level 01");
		Terminal.WriteLine ("2. Level 02");

	}

	void OnUserInput (string Input)
	{
		if (Input == "menu") {
			StartMenu ();
		} else if(Input == "quit" || Input == "close" || Input == "exit"){
			Application.Quit ();
		} else if (CurrentScreen == Screen.MainMenu) {
			RunMainMenu (Input);
		} else if (CurrentScreen == Screen.Password) {
			CheckPassward (Input);
		}
	}

	void RunMainMenu (string Input)
	{
		bool isValidNumber = (Input == "1" || Input == "2");

		if (isValidNumber) {
			level = int.Parse (Input);
			AskForPassword ();
		} else {
			Terminal.WriteLine ("enter a valid input");
			Terminal.WriteLine (menuHint);
		}
	}

	void AskForPassword ()
	{
		CurrentScreen = Screen.Password;
		Terminal.ClearScreen ();

		SetRandomPassword ();
		Terminal.WriteLine ("Enter your passward, hint: " + passward.Anagram());

	}

	void SetRandomPassword(){
	
		switch (level) {
		case 1:
			passward = level1Passwords[Random.Range (0, level1Passwords.Length)];
			break;
		case 2:
			passward = level2Passwords[Random.Range (0, level2Passwords.Length)];
			break;
		default:
			Debug.LogError ("Invalid level number");
			break;
		}

	}

	void CheckPassward (string Input)
	{
		if (Input == passward) {

			DisplayWinScreen ();

		} else {
			AskForPassword();
		}
	}

	void DisplayWinScreen(){
		CurrentScreen = Screen.Win;
		Terminal.ClearScreen ();
		ShowLevelReward ();
		Terminal.WriteLine (menuHint);
	}

	void ShowLevelReward(){
		switch (level) {
		case 1:
			Terminal.WriteLine ("Have a book.......");
 			Terminal.WriteLine (@"
    ________
   /       //
  /       //
 /_______//
(_______(/
"           );
			break;
		case 2:
			Terminal.WriteLine ("You got a prison Key!.......");
			Terminal.WriteLine (@"
 ____
/0   \__________
\____/-=' = ' = '
"           );
			break;
		default:
			Debug.LogError ("it's Ok");
			break;
		}

	}

}
