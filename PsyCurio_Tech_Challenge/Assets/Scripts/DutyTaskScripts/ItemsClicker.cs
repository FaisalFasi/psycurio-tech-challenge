using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsClicker : MonoBehaviour
{
    float timer = 5f;
    bool timerCheck = false;
    SoundController soundController;

    void Start()
    {
        soundController = GameObject.FindObjectOfType<SoundController>();
        if (soundController != null)
            soundController.InGamePlay();
    }
    void Update()
    {
        //delay of 3 sec between selecting new items
        if (timerCheck) 
        {
            timer -= Time.deltaTime;
            if (timer <= 0) 
            {
                timer = 5;
                timerCheck = false;
            }
        }
        //getting inputs 
        if (Input.GetMouseButtonDown(0)) 
        {
            if (soundController != null)
                soundController.ButtonClickPlay();
            if (timerCheck == false)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    //checking which item is got clicked
                    if (hit.transform.gameObject)
                    {
                        GameController.instance.ClickedItem(hit.transform.gameObject, hit.transform.gameObject.name);
                        timerCheck = true;
                    }
                }
            }
            else 
            {
                UI_Controller ui_controller = GameObject.FindObjectOfType<UI_Controller>();
                ui_controller.PleaseWaitTxt();
            }
        }
    }
}
