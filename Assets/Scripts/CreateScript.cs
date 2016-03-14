
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CreateScript : MonoBehaviour {
	public Canvas sceneCanvas;
	public RectTransform sceneSelector;
	public GameObject itemSelector;
	public GameObject stickerSelector;
	public Transform startPos;

	public GameObject sideBar;
	public GameObject stickerSidebar;
	public Button btnMenu;

	public GameObject sceneScroller;
	public GameObject themeScroller;

	private Animator anim;
	private Animator animStickers;
	private Dictionary<string, Sprite> stickerSprites = new Dictionary<string, Sprite>();
	private HashSet<string> themes = new HashSet<string>();

	private bool sideBarActive = false;
	private bool stickerBarActive = false;

	void Start() {
		toggleScenePanel(true);

		populateMenus("BackgroundThumbnails", "Scene", sceneScroller);
		addListeners(sceneScroller);
		populateSidebar();
		addListeners(themeScroller);

		anim = sideBar.GetComponent<Animator>();
		anim.enabled = false;

		animStickers = stickerSidebar.GetComponent<Animator>();
		animStickers.enabled = false;
	}

	void addListeners(GameObject section) {
		foreach (Transform child in section.transform) {
			// Save name of each child to memory
			string captured = child.name;
			string spriteName = child.gameObject.GetComponent<Image>().sprite.name;
			switch (section.name) {
				case "SceneSelectionPanel":
					// Add listener to Scene selections
					child.GetComponent<Button>().onClick.AddListener(() => changeImage(captured));
					break;
				case "ThemeSelectionPanel":
					// Add listener to theme selections
					child.GetComponent<Button>().onClick.AddListener(() => selectTheme(captured));
					break;
				case "StickerSelectionPanel":
					// Add listeners to stickers
					Debug.Log(captured);
					child.GetComponent<Button>().onClick.AddListener(() => addSticker(captured));
					break;
			}
		}
	}

	void changeImage(string name) {
		name = Regex.Replace(name, "[0-9]", "");
		string sceneName = "Backgrounds/"+name+"Scene";
		Texture2D background = Instantiate(Resources.Load(sceneName)) as Texture2D;
		Rect r = new Rect(0, 0, background.width, background.height);

		sceneCanvas.GetComponent<Image>().sprite = Sprite.Create(background, r, new Vector2());
		toggleScenePanel(false);

		// Start with Sidebar displayed
		anim.enabled = true;
		sideBarButton();
    }

	void selectTheme(string theme) {
		// Check if scene resources have already been imported
		if(themes.Contains(theme)) {
			// Change visible theme 
			return;
		}

		themes.Add(theme);
        string themeName = "Stickers/" + theme;
		stickerBarActive = true;
		deleteChildren(stickerSelector);
		populateMenus(themeName, "StickerSelector", stickerSelector);

		addListeners(stickerSelector);
		animStickers.enabled = true;
		slideIn(animStickers);
	}

	void deleteChildren(GameObject go) {
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in go.transform) {
			children.Add(child.gameObject);
		}
		go.transform.DetachChildren();

		foreach (GameObject g in children) {
			stickerSprites.Clear();
			Destroy(g);
		}
	}

	void populateSidebar() {
		populateMenus("Themes", "Theme", itemSelector);

		foreach (Transform theme in itemSelector.transform) {
			// Remove numbers from file name
			theme.name = Regex.Replace(theme.name, "[0-9]", "");
            theme.GetChild(0).GetComponent<Text>().text = theme.name;
		}
	}

	private void slideIn(Animator temp) {
		temp.Play("SlideIn");
	}

	private void slideOut(Animator temp) {
		temp.Play("SideBarSlideOut");
	}

	public void sideBarButton() {
		if(!stickerBarActive) {
			if (sideBarActive) {
				slideOut(anim);
				sideBarActive = false;
				btnMenu.transform.GetChild(0).GetComponent<Text>().text = "Menu";
			} else {
				btnMenu.transform.GetChild(0).GetComponent<Text>().text = "Cancel";
				slideIn(anim);
				sideBarActive = true;
			}
		} else {
			slideOut(animStickers);
			stickerBarActive = false;
		}
	}

	void addSticker(string name) {
		// Spawn a new sticker in the middle of the game area
		GameObject sticker = Instantiate(Resources.Load("Sticker")) as GameObject;
		// TODO - Create slider that determines scale of object

		Sprite temp = stickerSprites[name];
		sticker.name = name;
		sticker.GetComponent<Image>().sprite = temp;
		sticker.transform.position = startPos.transform.position;
		Debug.Log("New Sticker " + name);

		sticker.transform.SetParent(startPos.transform.parent, true);
	}

	private void populateMenus(string resource, string prefab, GameObject parent) {
		foreach (Texture2D t in Resources.LoadAll(resource, typeof(Texture2D))) {
			Rect r = new Rect(0, 0, t.width, t.height);
			GameObject i = Instantiate(Resources.Load(prefab)) as GameObject;
			Sprite temp = Sprite.Create(t, r, new Vector2());
            i.GetComponent<Image>().sprite = temp;


			if (prefab.Equals("StickerSelector")) {
				stickerSprites.Add(t.name, temp);
			}

			i.transform.SetParent(parent.transform);
			i.transform.position = i.transform.parent.position;
			i.name = t.name;
		}
	}

	void toggleScenePanel(bool activate) {
		CanvasGroup cg = sceneSelector.GetComponent<CanvasGroup>();

		if (activate) {
			cg.alpha = 1;
			cg.blocksRaycasts = true;
			cg.interactable = true;
		} else {
			cg.alpha = 0;
			cg.blocksRaycasts = false;
			cg.interactable = false;
		}
	}
}
