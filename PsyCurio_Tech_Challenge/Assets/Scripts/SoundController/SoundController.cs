using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    //getting refrence of audio clips in the inspector
    public AudioClip menuMusic, btnClickSound, ingameMusic, danceSound;
    //getting audio source
    public AudioSource audioLoop, audioPlayOneShoot;
    public GameObject musicBtn;
 
    public static SoundController instance_;

    public void Awake()
    { 
        if (instance_ == null)
        {
            DontDestroyOnLoad(gameObject);
            instance_ = this;
        }
        else if (instance_ != this)
        {
            Destroy(gameObject);
        }
    }
  
    public void MenuMusicPlay()
    {     
        if (Constant.IsMusicOn())
        {
            audioLoop.clip = menuMusic;
            audioLoop.Play();
        }
    }

    public void SetPlayerPrefValue(string instrument, int isEnable)
{
    PlayerPrefs.SetInt(instrument, isEnable);
}

	 
    public void InGamePlay()
    {
        StopMusicPlay();
        if (Constant.IsMusicOn())
        {
            audioLoop.clip = ingameMusic;
            audioLoop.Play();
        }
    }
	  
    public void StopMusicPlay()
    {
        audioLoop.Stop();
    }

    public void ButtonClickPlay()
    {
        if (Constant.IsSoundOn())
        {
            audioPlayOneShoot.PlayOneShot(btnClickSound, 1);
        }
    }
    public void DanceSound()
    {
        if (Constant.IsSoundOn())
        {
            audioPlayOneShoot.PlayOneShot(danceSound, 1);
        }
    }

}