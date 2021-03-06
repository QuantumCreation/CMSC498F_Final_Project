// This script is for the number codes
// Attach it to the text that will be the number
// Assign the main camera GO to the 'GameObject camera' in Unity
// Asign the up button GO to the 'GameObject up' in Unity
// Asign the down button GO to the 'GameObject down' in Unity



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeValue : MonoBehaviour
{

    public int value = 0;
    public GameObject camera;
    public GameObject up;
    public GameObject down;

    void Update()
    {
        this.gameObject.transform.GetComponent<TextMesh>().text = value.ToString();

        if (Input.GetKeyDown(KeyCode.U)){
            print("U");
            RaycastHit result;
            if (Physics.Raycast(camera.gameObject.transform.position,camera.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);

                if (result.collider.gameObject == up) {
                    print("up");
                    if (value < 9) {
                        value++;
                    }
                    else {
                        value = 9;
                    }
                }
                else if (result.collider.gameObject == down) {
                    print("up");
                    if (value > 0) {
                        value--;
                    }
                    else {
                        value = 0;
                    }
                }
            }
        }
    }
}
