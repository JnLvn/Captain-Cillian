using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonClicked : MonoBehaviour {

	private static string selectedButton = null;
	HashSet<string> words = new HashSet<string>();
	public List<Button> buttons = new List<Button>();

	public Button b1;
	public Button b2;
	public Button b3;
	public Button b4;
	public Button b5;
	public Button b6;
	public Button b7;
	public Button b8;

	string[] values = new string[] { "madra", "teach", "ceithre", "cuig" };

	private bool srtBool = false;
	
	void Start () {
		for (int i = 0; i < 7; i++) {
			buttons.Add(b1);
			buttons.Add(b2);
			buttons.Add(b3);
			buttons.Add(b4);
			buttons.Add(b5);
			buttons.Add(b6);
			buttons.Add(b7);
			buttons.Add(b8);
		}

		string[] pictures = values;

		foreach(string value in values) {
			int val = Random.Range(0, values.Length);

		}
	}

	public void clicked(string btnName) {

		if (selectedButton == null) selectedButton = btnName;

		else if (selectedButton == btnName) selectedButton = null;

		else {

		}
	}

	public void getSound(string soundName)
	{
		switch(soundName)
		{
		case "button":
			Debug.Log("Button pressed");
			break;
		}
	}
}
