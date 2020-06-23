using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOfEnemy : MonoBehaviour
{
    // getting material refrence
    Material enemyMaterial;
    void OnTriggerEnter(Collider other)
    {
        // checking when it enter into trigger zone
        if (other.gameObject.name == "TriggerZone") {
            ChangeColor();
        } 
    }
    // changing the color
    void ChangeColor() 
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
