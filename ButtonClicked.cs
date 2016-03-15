using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour {

	public GameObject butPic1;
	public GameObject butWord1;
	public GameObject butPic2;
	public GameObject butWord2;
	public GameObject butPic3;
	public GameObject butWord3;
	public GameObject butPic4;
	public GameObject butWord4;

	private int pic1 = 0;
	private int pic2 = 100;
	private int pic3 = 400;
	private int pic4 = 600;
	private int word1 = 200;
	private int word2 = 300;
	private int word3 = 500;
	private int word4 = 700;

	private int clickCount = 0;

	private bool srtBool = false;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		/*if (clickCount > 0) {
			srtBool = true;
		}*/

		//while (srtBool) {

			/*if(clickCount % 2 == 1)
			{
				Debug.Log ("Odd");
				pic1 = 0;
				pic2 = 100;
				word1 = 200;
				word2 = 300;
				
				srtBool = false;
			}*/

			if(clickCount % 2 == 0)
			{
				clickCount = 0;
				if (pic1 == word1) {

					butPic1.SetActive (false);
					butWord1.SetActive (false);
				} 

				if (pic2 == word2) {

					butPic2.SetActive (false);
					butWord2.SetActive (false);
				} 
				if (pic3 == word3) {
				
					butPic3.SetActive (false);
					butWord3.SetActive (false);
				} 
				if (pic4 == word4) {
				
					butPic4.SetActive (false);
					butWord4.SetActive (false);
				} 
				else{
				Debug.Log("Reached");
					pic1 = 0;
					pic2 = 100;
					pic3 = 400;
					pic4 = 600;
					word1 = 200;
					word2 = 300;
					word3 = 500;
					word4 = 700;
				}


				

				//Debug.Log ("Even");
				//srtBool = false;

			}// end if


		
		//}// end while 
		







	}

	public void setPic1(int picNum)
	{
		pic1 = picNum;
		Debug.Log ("pic1 = " + pic1);
	}

	public void setPic2(int picNum2)
	{
		pic2 = picNum2;
		Debug.Log ("pic2 = " + pic2);
	}

	public void setPic3(int picNum3)
	{
		pic3 = picNum3;
		Debug.Log ("pic3 = " + pic3);
	}

	public void setPic4(int picNum4)
	{
		pic4 = picNum4;
		Debug.Log ("pic4 = " + pic4);
	}

	public void setWord1(int wrdNum)
	{
		word1 = wrdNum;
		Debug.Log ("word1 = " + word1);
	}
	
	public void setWord2(int wrdNum2)
	{
		word2 = wrdNum2;
		Debug.Log ("word2 = " + word2);
	}

	public void setWord3(int wrdNum3)
	{
		word3 = wrdNum3;
		Debug.Log ("word3 = " + word3);
	}

	public void setWord4(int wrdNum4)
	{
		word4 = wrdNum4;
		Debug.Log ("word4 = " + word4);
	}

	public void setClickCount()
	{
		clickCount++;
		Debug.Log ("clickCount = " + clickCount);
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
