using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    // refrence for player
    public GameObject player;
    // checking distance from player to enemy/npc 
    float distanceFromPlayer;
    // for keeping this much distance between enmy and player
    float _KeepDistance = 3;
    public float followSpeed = 2f;
    public RaycastHit shot;
    float initFollowSpeed;

    void Start()
    {
         initFollowSpeed = followSpeed;
    }

    void Update()
    {
         // With rayCast
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            followSpeed = initFollowSpeed;
            distanceFromPlayer = shot.distance;
            if (distanceFromPlayer >= _KeepDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime*followSpeed );
            }
            else
            {
                followSpeed = 0;
            }
           
        }
    }
}
