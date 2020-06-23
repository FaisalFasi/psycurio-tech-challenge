using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCounter : MonoBehaviour
{ 
    void Update()
    {
        // moving object to the counter
        GameController.instance.MoveInstantiatedPotsToCounter();
    }
}
