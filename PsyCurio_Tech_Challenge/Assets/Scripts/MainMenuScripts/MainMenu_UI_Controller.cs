using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI_Controller : MonoBehaviour
{
    SoundController soundController;

    void Start()
    {
        soundController = GameObject.FindObjectOfType<SoundController>();
        if(soundController != null)
        soundController.MenuMusicPlay();
    }
    public void LoadDutyTaskScene()
    {
        SceneManager.LoadScene("Duty_Task");
        if (soundController != null)
            soundController.ButtonClickPlay();
    }
    public void LoadLiveCodingScene()
    {
        SceneManager.LoadScene("Live_Coding");
        if (soundController != null)
            soundController.ButtonClickPlay();
    }
    public void LoadPermutationScene()
    {
        SceneManager.LoadScene("Permutation");
        if (soundController != null)
            soundController.ButtonClickPlay();
    }
}
