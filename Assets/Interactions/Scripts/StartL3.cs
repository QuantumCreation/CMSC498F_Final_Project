// This script is for switching to level 2 after completino of level 1
// Attach it to AROrigin in L1


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartL3 : MonoBehaviour
{

    public GameObject final;

    void Update()
    {
        if (!(final.gameObject)) {
            print("LEVEL COMPLETE!");
            SceneManager.LoadScene (sceneName: "Level3");
        }
    }
}
