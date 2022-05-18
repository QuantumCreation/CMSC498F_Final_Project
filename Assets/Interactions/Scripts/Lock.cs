// This script is for unlocking locks with colected keys
// Attach it to collider on the locked door
// Assign the main camera GO to the 'GameObject camera' in Unity
// Assign the corresponding key GO to the 'GameObject key' in Unity

// When the door is interacted with, if it can find the GO associated with 'key' then it will not unlock


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public GameObject camera;
    public GameObject key;
    public GameObject door;

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.U)){
            print("U");
            RaycastHit result;
            if (Physics.Raycast(camera.gameObject.transform.position,camera.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);

                if (result.collider.gameObject == this.gameObject) {
                    print("unlock?");
                    if (!(key.gameObject)) {
                        print("UNLOCKED!");
                        Destroy(door.gameObject);
                    }
                }
            }
        }
    }
}
