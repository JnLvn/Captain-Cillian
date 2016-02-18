using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
	public Button btnURL;
	public GameObject pnlURL;
	private CanvasGroup cgURL;
	public Button btnLanguage;
	public Text txtLanguage;
	private string[] languages = new string[2];

	public void Start() {
		languages[0] = "English";
		languages[1] = "Irish";
		if(PlayerPrefs.GetString("Language") == null) {
			PlayerPrefs.SetString("Language", languages[0]);
		}

		cgURL = pnlURL.GetComponent<CanvasGroup>();
	}

	public void openLink() {
		Application.OpenURL("http://www.captaincillian.com/");
    }

	public void setLanguage() {
		if(PlayerPrefs.GetString("Language") == languages[0]) {
			PlayerPrefs.SetString("Language", languages[1]);
		} else {
			PlayerPrefs.SetString("Language", languages[0]);
		}
		txtLanguage.text = PlayerPrefs.GetString("Language");
		// translate()
	}

	private void translate() {
		// Changes language throughout scene when the language is changed
		
	}

	// Update is called once per frame
	public void toggleURLPanel() {
		// If panel is invisible and button is clicked
		if (cgURL.alpha == 0) {
			cgURL.alpha = 1;
			cgURL.interactable = true;
			cgURL.blocksRaycasts = true;
		} else {
			cgURL.alpha = 0;
			cgURL.interactable = false;
			cgURL.blocksRaycasts = false;
		}
	}
}
