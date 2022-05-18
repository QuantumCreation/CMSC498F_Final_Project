// This script is for the button to confirm a GEAR TASK entry
// Attach it to the button/lever that is used to confirm code
// Assign the main camera GO to the 'GameObject camera' in Unity
// Asign the door this button controls GO to the 'GameObject door' in Unity
// Assign the first number text GO or gear GO to the 'GameObject numberCode1' in Unity
// Assign the second number text GO or gear GO to the 'GameObject numberCode2' in Unity
// Assign a number 0-9 to the 'GameObject value1' in Unity
// Assign a number 0-9 to the 'GameObject value2' in Unity
// If you want to add another number:
        // create 'public GameObject numberCode3;'
        // create 'public int value3;'
        // add 'if (numberCode3.gameObject.transform.GetComponent<TextMesh>().text == value3.ToString()) {' at indicated line



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmGear : MonoBehaviour
{

    public GameObject camera;
    public GameObject door;
    public GameObject numberCode1;
    public GameObject numberCode2;
    public int value1;
    public int value2;
    public bool locked = true;
    public bool isLever;

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.U)){
            print("U");
            RaycastHit result;
            if (Physics.Raycast(camera.gameObject.transform.position,camera.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);

                if (result.collider.gameObject == this.gameObject) {
                    print("confirm?");
                    if (numberCode1.GetComponent<GearTask>().value == value1) {
                        if (numberCode2.GetComponent<GearTask>().value == value2) {
                            // add another if statement here for more numbers
                            print("UNLOCKED!");
                            locked = false;
                            if (isLever == true) {
                                this.transform.GetChild(0).gameObject.transform.Rotate(-90.0f, 0.0f, 0.0f);
                            }
                            Destroy(door.gameObject);
                        }
                    }
                }
            }
        }
    }
}
