using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour

{
    public float pickUp = 5;
    private GameObject heldObj;
    public Transform holdParent;
    public float moveForce = 250;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if(heldObj == null) {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUp)) {
                PickUpObj(hit.transform.gameObject);
            }
            } else {
                DropObj();
            }
        }
        if(heldObj != null){
            MoveObj();
        }

    }


void DropObj(){
    Rigidbody held = heldObj.GetComponent<Rigidbody>();
    held.useGravity = true;
    held.drag = 1;
    heldObj.transform.parent = null;
    heldObj = null;
}


    void MoveObj(){
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f) {
            Vector3 moveDir = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDir * moveForce);
        }
    }

    void PickUpObj(GameObject pickObj) {
        if(pickObj.GetComponent<Rigidbody>()) {
           Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
           objRig.useGravity = false;
           objRig.drag = 10;
           objRig.transform.parent = holdParent;
           heldObj = pickObj;
        }
    }
}
