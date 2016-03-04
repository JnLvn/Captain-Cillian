
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateScript : MonoBehaviour {
	public GameObject scenes;
	public GameObject sideBar;
	private RectTransform activePanel;
	private Animator anim;
	private bool sideBarActive = false;

	void Start() {
		List<Texture2D> backgrounds = new List<Texture2D>();
		Debug.Log("Started");
		foreach (Texture2D t in Resources.LoadAll("Backgrounds", typeof(Texture2D))) {
			//backgrounds.Add(t);
			
		}

		Time.timeScale = 1;
		anim = sideBar.GetComponent<Animator>();
		anim.enabled = false;
	}

	// Update is called once per frame
	void Update() {
		float beginPos = 0f;
		foreach (Touch t in Input.touches) {
			if(t.phase == TouchPhase.Began) {
				beginPos = t.position.x;
			}
			if (t.phase == TouchPhase.Ended) {
				if (!sideBarActive) {
					slideIn();
					sideBarActive = true;
				} else {
					slideOut();
					sideBarActive = false;
				}
			}
		}
	}

	private void slideIn() {
		//enable the animator component
		anim.enabled = true;
		//play the Slidein animation
		anim.Play("SlideIn");
		//set the isPaused flag to true to indicate that the game is paused
	}

	private void slideOut() {
		//play the SlideOut animation
		anim.Play("SideBarSlideOut");
	}

	public void sideBarButton() {
		if (sideBarActive) {
			slideOut();
			sideBarActive = false;
			return;
		} else
			slideIn();
			sideBarActive = true;
	}
}
