// Script to end game if Reaper hits you
// Attach to Reaper

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    public GameObject camera;

    void OnTriggerEnter(Collider other){
        print("I, "+this.gameObject.name+" overlapped another collectible called "+other.gameObject.name);
        print("GAME OVER");
        SceneManager.LoadScene (sceneName: "GameOver");
    }
}