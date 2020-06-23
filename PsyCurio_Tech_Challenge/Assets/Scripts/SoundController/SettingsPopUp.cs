using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsPopUp : MonoBehaviour {
	public Sprite[] btnImgList;
	public Image soundImg, musicImg;
//    IntegrationManager adsObj;


    SoundController soundController;

    void OnEnable()
    { 
    }
    void Awake()
	{
		soundController = GameObject.FindObjectOfType<SoundController> ();
	}

	// Use this for initialization
	                                
	void Start () {
		UI_Update ();
	}

	void UI_Update()
	{
		//sound ui init
		if (Constant.IsSoundOn ()) {
			soundImg.overrideSprite = btnImgList [0];// true
		}else{
			soundImg.overrideSprite = btnImgList [1];// f
		}

		//music ui init
		if (Constant.IsMusicOn ()) {
			musicImg.overrideSprite = btnImgList [2];// true
		}else{
			musicImg.overrideSprite = btnImgList [3];// false
		}

	}

	public void CloseBtnClick()
	{
 
        soundController.ButtonClickPlay ();
		this.gameObject.SetActive (false);
 
    }

	public void SoundBtnClick()
	{
		Debug.Log ("sound == " + Constant.IsSoundOn ());

		if (Constant.IsSoundOn ()) {
			PlayerPrefs.SetInt ("IsSoundOn", 1);
		} else {
			PlayerPrefs.SetInt ("IsSoundOn", 0);
		}
		soundController.ButtonClickPlay ();
		UI_Update ();
	}
	public void MusicBtnClick()
	{
		soundController.ButtonClickPlay ();

		if (Constant.IsMusicOn ()) {
			PlayerPrefs.SetInt ("IsMusicOn", 1);
			soundController.StopMusicPlay ();
		} else {
			PlayerPrefs.SetInt ("IsMusicOn", 0);
			soundController.MenuMusicPlay ();
		}

		UI_Update ();
	}
}
