using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    //this gameObject will hold the refrence of instantiated items
    GameObject purchasedPot;
    //items which will be instantiated
    public GameObject[] potsPrefabs;
    // positions of items on counter
    public GameObject[] potsCounterPos;
 
    int itemNo = 0;
    int totalBill = 0;
    bool skipFirstTime = false;
    UI_Controller ui_controller;
    SoundController soundController;

    void Awake() 
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        ui_controller = GameObject.FindObjectOfType<UI_Controller>();
        soundController = GameObject.FindObjectOfType<SoundController>();
        itemNo = 0;
        totalBill = 0;
        skipFirstTime = false;
    }
    //it will check which item has been clicked and will respond against that click
    public void ClickedItem(GameObject obj, string name)
    {
         for (int i = 0; i < potsPrefabs.Length; i++)
        {
            if (potsPrefabs[i].name == name && skipFirstTime == false)
            {
                totalBill += 1;
                skipFirstTime = true;
                DanceAnimAndSound();
            }
            else if (potsPrefabs[i].name == name && skipFirstTime)
            {
                totalBill += 1;
                itemNo += 1;
                DanceAnimAndSound();
                if (totalBill >= 5) 
                {
                    //disabling click event
                    GameObject.FindGameObjectWithTag("Player").GetComponent<ItemsClicker>().enabled = false;
                    //showing the total bill of selected items
                    ui_controller.ShowBillTextOnScreen(totalBill, BillCounter(totalBill));
                }
            }
        }
         // deciding which object will be instantiated
        switch (name)
        {
            case "Pot_1":
                InstantiatePot(potsPrefabs[0], obj.transform.position);
            break;
            case "Pot_2":
                InstantiatePot(potsPrefabs[1], obj.transform.position);
                break;
            case "Pot_3":
                InstantiatePot(potsPrefabs[2], obj.transform.position);
                break;
            case "Pot_4":
                InstantiatePot(potsPrefabs[3], obj.transform.position);
                break;
            case "Pot_5":
                InstantiatePot(potsPrefabs[4], obj.transform.position);
                break;
             
            case "CashRegisterCollider":
                ui_controller.ShowBillTextOnScreen(totalBill, BillCounter(totalBill));
                break;
        }
        
    }
    //instantiating items
    void InstantiatePot(GameObject obj , Vector3 pos) 
    {
        purchasedPot = Instantiate(obj, pos, obj.transform.rotation) as GameObject;
    }
    //moving item to counter
   public void MoveInstantiatedPotsToCounter() 
    {
        purchasedPot.transform.position = Vector3.MoveTowards(purchasedPot.transform.position,
            potsCounterPos[itemNo].transform.position, Time.deltaTime * 2f);
    }

    // dance animation and sound
    void DanceAnimAndSound()
    {
        GameObject.Find("ShopKeeper").GetComponent<Animator>().SetTrigger("Dance");
        if (soundController != null)
            soundController.DanceSound();
    }
    //updating bill
    int BillCounter(int bill) 
    {
        
        int tmp = 10;
        tmp *= bill;

        return tmp;
    }
}
 