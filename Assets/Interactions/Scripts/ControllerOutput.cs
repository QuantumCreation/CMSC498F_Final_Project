// This script isnt nescessary
// More just for debuggin purposes
// You can add it anywhere in the scene if you need it



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOutput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // @+C mode for vertical
        // @+B mode for horizontal

        foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(KeyCode.U)) {
                print("a/z pressed");
            }
            else if (Input.GetKeyUp(KeyCode.U)) {
                print("a/z released");
            }

            if (Input.GetKeyDown(KeyCode.H)) {
                print("b/r pressed");
            }
            else if (Input.GetKeyUp(KeyCode.H)) {
                print("b/r released");
            }


            // movement

            if (Input.GetKeyDown(KeyCode.W)) {
                print("forward pressed");
            }
            else if (Input.GetKeyUp(KeyCode.W)) {
                print("forward released");
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                print("left pressed");
            }
            else if (Input.GetKeyUp(KeyCode.A)) {
                print("left released");
            }

            if (Input.GetKeyDown(KeyCode.X)) {
                print("back pressed");
            }
            else if (Input.GetKeyUp(KeyCode.X)) {
                print("back released");
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                print("right pressed");
            }
            else if (Input.GetKeyUp(KeyCode.D)) {
                print("right released");
            }
        }

    }
}
