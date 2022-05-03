// This script is for the gear task
// Attach it to the gear that will be rotated
// Assign the main camera GO to the 'GameObject camera' in Unity
// Make sure that the gear is facing you with the number 0 on the top spoke so that it roatates correctly



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTask : MonoBehaviour
{

    public int value = 0;
    public GameObject camera;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.U)){
            print("U");
            RaycastHit result;
            if (Physics.Raycast(camera.gameObject.transform.position,camera.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);
                if (result.collider.gameObject == this.gameObject) {
                    print("rotate gear");
                    this.gameObject.transform.Rotate(0.0f, 36.0f, 0.0f, Space.Self);
                    if (value < 9) {
                        value++;
                    }
                    else {
                        value = 0;
                    }
                }
            }
        }
    }
}
