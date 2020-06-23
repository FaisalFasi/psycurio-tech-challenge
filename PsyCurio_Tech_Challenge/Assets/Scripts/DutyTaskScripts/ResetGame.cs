using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    Color enemyCol;

    Vector3 playerPos, playerRot;
    Vector3 enemyPos, enemyRot;
    SoundController soundController;

    void Start()
    {
        soundController = GameObject.FindObjectOfType<SoundController>();
        if (soundController != null)
            soundController.InGamePlay();
        //getting the positions of objects in start so that later we can reset it
        playerPos = player.transform.position;
        playerRot = player.transform.rotation.eulerAngles;

        enemyPos = enemy.transform.position;
        enemyRot = enemy.transform.rotation.eulerAngles;
        enemyCol = enemy.GetComponent<Renderer>().material.color;
    }

    // resetting the objects positions
    // we can also store values of objects into a txt file 
    // it was only 2 objects that's why i used this quick way
    public void ResetTheGame() 
    {
        player.transform.position = playerPos;
        player.transform.rotation = Quaternion.Euler(playerRot.x, playerRot.y,playerRot.z);

        enemy.transform.position = enemyPos;
        enemy.transform.rotation = Quaternion.Euler(enemyRot.x, enemyRot.y, enemyRot.z);
        enemy.GetComponent<Renderer>().material.color = enemyCol;

        if (soundController != null)
            soundController.ButtonClickPlay();
    }

    public void MainMeu()
    {
        SceneManager.LoadScene("MainMenu");
        if (soundController != null)
            soundController.ButtonClickPlay();
    }

}
