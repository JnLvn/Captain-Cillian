using UnityEngine;

using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class ClickDragScript : MonoBehaviour {
	public Transform gameCanvas;
	public Transform gamePanel;
	private Vector3 screenPoint; private Vector3 offset; private float _lockedYPosition;
	private GameObject activeSticker;
	private float scaleFactor = 0.5f;        // The rate of change of the scale

	private float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	private float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.

	void Start() {
		gameCanvas = GameObject.Find("Canvas").transform;
		gamePanel = GameObject.Find("GamePanel").transform;
	}

	void Update() {
		if (Input.touchCount == 2) {

			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			if(activeSticker != null) {
				activeSticker.transform.localScale += new Vector3(deltaMagnitudeDiff, deltaMagnitudeDiff, scaleFactor);
			}
		}
	}
	void OnMouseDown() {
		if(Input.touchCount == 1) {
			// Center object on camera
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			// Set the active sticker as the last one dragged
			activeSticker = gameObject;
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
			Cursor.visible = false;
		}
	}

	void OnMouseDrag() {
		if(Input.touchCount == 1) {
			transform.SetParent(gameCanvas);
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}

	void OnMouseUp() {
		transform.SetParent(gamePanel);
		Cursor.visible = true;
	}
}