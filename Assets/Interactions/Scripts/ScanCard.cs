// This script is for the number codes
// Attach it to the text that will be the number
// Assign the main camera GO to the 'GameObject camera' in Unity
// Asign the up button GO to the 'GameObject up' in Unity
// Asign the down button GO to the 'GameObject down' in Unity



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanCard : MonoBehaviour
{

    public GameObject camera;
    public GameObject key;
    private string value = "Scan Here";
    public int numCode;

    void Update()
    {
        this.gameObject.transform.GetComponent<TextMesh>().text = value;

        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.U)){
            print("U");
            RaycastHit result;
            if (Physics.Raycast(camera.gameObject.transform.position,camera.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);

                if (result.collider.gameObject == this.gameObject) {
                    print("unlock?");
                    if (!(key.gameObject)) {
                        print("CODE UNLOCKED!");
                        value = numCode.ToString();
                    }
                }
            }
        }
    }
}
