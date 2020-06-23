using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // getting player refrence
    public GameObject player;
    // stopping distance from player
    float stoppingDistance = 3f;
    // enemy or NPC movment speed
    public float enemySpeed = 5f;
    
    void Update()
    {
        // transform.LookAt(player.transform);
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemySpeed * Time.deltaTime);

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        // checking stopping distance from player
        if (distance > stoppingDistance ) 
        {
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        } 
    }
}