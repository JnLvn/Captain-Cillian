using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigationScript : MonoBehaviour {

	// Manages the navigations between different scenes
    public void loadExploreScene() {
       SceneManager.LoadScene("Explore");
    }

    public void loadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadLearnScene() {
        SceneManager.LoadScene("Learn");
    }

    public void loadCreateScene() {
        SceneManager.LoadScene("Create");
    }

    public void loadFunScene() {
        SceneManager.LoadScene("Fun");
    }
}
