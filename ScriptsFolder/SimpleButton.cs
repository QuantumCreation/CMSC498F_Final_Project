using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{

    public GameObject camera;
    public GameObject door;
    public bool locked = true;
    public bool isLever;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)){
            print("U");
            RaycastHit result;
            if (Physics.Raycast(camera.gameObject.transform.position,camera.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);

                if (result.collider.gameObject == this.gameObject) {
                    print("UNLOCKED");
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
