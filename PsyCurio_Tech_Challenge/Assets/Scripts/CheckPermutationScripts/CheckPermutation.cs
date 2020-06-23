using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckPermutation : MonoBehaviour
{
    public InputField string1;
    public InputField string2;
    public Text permutationResultTxt;
    // instance of soundController class 
    SoundController soundController;

    void Start() 
    {
        soundController = GameObject.FindObjectOfType<SoundController>();
        if (soundController != null)
            soundController.InGamePlay();
    }

    // this method checks the weather the strings are permutations or not
    static bool checkPermutation(String s1, String s2)
    {
        int s1length = s1.Length;
        int s2length = s2.Length;
        // here we check if string lenths are equal or not
        if (s1length != s2length)
            return false;
        // converting string into charracter arrays
        char[] chArray1 = s1.ToCharArray();
        char[] chArray2 = s2.ToCharArray();
        // sorting character arrays
        Array.Sort(chArray1);
        Array.Sort(chArray2);
        // checking if arrays are same or not
        for (int i = 0; i < s1length; i++)
            if (chArray1[i] != chArray2[i])
                return false;

        return true;
    }

    public void CheckPermutation_() 
    {
        if (checkPermutation(string1.text, string2.text))
            permutationResultTxt.text = "One String is a permutation to other String. "; 
         else
            permutationResultTxt.text = "One String is not a permutation to other String. ";
        StartCoroutine(ClosePermutationTxt());
      
        if (soundController != null)
            soundController.ButtonClickPlay();
    }
    IEnumerator ClosePermutationTxt() 
    {
        yield return new WaitForSeconds(3f);
        permutationResultTxt.text = " ";
    }

    public void MainMeu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
