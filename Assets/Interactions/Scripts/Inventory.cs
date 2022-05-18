// This script is for processing the player's inventory
// Attach it to the main camera GO
// Assign a key to each 'public GameObject key[]' in Unity

// Inventory currently cannot be viewed
    // GO is destroyed and this means that when the lock is interacted with for destroyed key it will open



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject key1;
    public GameObject key2;
    public GameObject exitTool;

    void Update()
    {

        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.H)){
            print("H");
            RaycastHit result;
            if (Physics.Raycast(this.gameObject.transform.position,this.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);

                if (result.collider.gameObject == key1) {
                    print("Key 1 collected");
                    Destroy(result.collider.gameObject);
                } 

                if (result.collider.gameObject == key2) {
                    print("Key 2 collected");
                    Destroy(result.collider.gameObject);
                } 

                if (result.collider.gameObject == exitTool) {
                    print("Exit Tool collected");
                    Destroy(result.collider.gameObject);
                } 
            }
        }
    }
}

