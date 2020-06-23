using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Controller : MonoBehaviour
{
    //show bill panel refrence object
    public GameObject showBillPanel;
    public GameObject waitTxt;
    public GameObject startTxt;

    public Text billTxt;

    void Start()
    {
        StartCoroutine(StartTxtShow());
    }

    public void ShowBillPanel() 
    {
        showBillPanel.SetActive(true);
    }
    public void ShowBillPanel_Closed()
    {
        showBillPanel.SetActive(false);
    }
    IEnumerator ShowBillTextOnScreen()
    {
        ShowBillPanel();
        yield return new WaitForSeconds(5f);
        ShowBillPanel_Closed();
    }
    //showing bill panel on the screen
    public void ShowBillTextOnScreen(int totalItems , int totalBill) 
    {
        billTxt.text = " You've chossed total " + totalItems + " pot and it will cost you " + totalBill + "$.";
        StartCoroutine(ShowBillTextOnScreen());
    }
    //enable the wait txt
    IEnumerator PLeaseTxtWait() 
    {
        waitTxt.SetActive(true);
        yield return new WaitForSeconds(2f);
        waitTxt.SetActive(false);
    }
    //total selecting items panel
    IEnumerator StartTxtShow()
    {
        startTxt.SetActive(true);
        yield return new WaitForSeconds(2f);
        startTxt.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<ItemsClicker>().enabled = true;
    }
    public void PleaseWaitTxt() 
    {
        StartCoroutine(PLeaseTxtWait());    
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene("Duty_Task");
    }
    public void MainMeu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
