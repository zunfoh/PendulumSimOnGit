using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//refact code
//use fixedjoint
//start to UI, like panel , so that user can start to interactive
//transform scaling, make it pecisely, position exactly , bar with capsule, 
public class GameManager : MonoBehaviour
{
    //float swingSpeed = 0.1f;
    //GameObject sphereForTest;
    GameObject rodForTest;
    GameObject hrBar;
    Rigidbody rodRigidbody;
    Rigidbody hrBarRigidbody;
    HingeJoint rodHingeJoint;



    // Start is called before the first frame update
    void Start()
    {
        SetBar();

        SetRod();
        
    }

    private void SetRod()
    {
        rodForTest = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        rodForTest.transform.localScale = new Vector3(0.5f, 1.7f, 0.5f);
        rodForTest.transform.Rotate(40.0f, 0.0f, 0.0f, Space.Self);

        rodHingeJoint = rodForTest.AddComponent<HingeJoint>();
        rodHingeJoint.connectedBody = hrBarRigidbody;
        //rodHingeJoint.autoConfigureConnectedAnchor = (false);
        //rodHingeJoint.connectedAnchor = new Vector3(hrBar.transform.position.x/2, hrBar.transform.position.y/4, hrBar.transform.position.z/2);

        rodRigidbody = rodForTest.GetComponent<Rigidbody>();
        rodRigidbody.useGravity = (false);
        rodRigidbody.isKinematic = (true);//could be a trigger when "false" is like real physics
    }

    private void SetBar()
    {
        hrBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hrBar.transform.localScale = new Vector3(1f, 1f, 4f);
        hrBar.transform.position = new Vector3(0f, 1.5f, 0.5f);
        hrBarRigidbody = hrBar.AddComponent<Rigidbody>();
        hrBarRigidbody.useGravity = (false);
        hrBarRigidbody.isKinematic = (true);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("s"))
        {
            rodRigidbody.useGravity = (true);
        }

        if (Input.GetKeyUp("k"))
        {
            rodRigidbody.isKinematic = (false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("HingeByScript");
        }

    }

    /* 
     * under Uptate:
     * 
     * {float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0f, zDirection);

        sphereForTest.transform.position += moveDirection * swingSpeed;}
     * 
     * 
     * GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
     * Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
     * gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.
     * 
     * 
     * //sphereForTest = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphereForTest.transform.position = new Vector3(-0.03f, -1.72f, 0.1f);
        //HingeJoint sphereHingeJoint = sphereForTest.AddComponent<HingeJoint>();
        //sphereHingeJoint.autoConfigureConnectedAnchor = (false);
        //sphereHingeJoint.connectedBody = rodRigidbody;


        //Rigidbody gameObjsRigidBody = sphereForTest.AddComponent<Rigidbody>();
        //gameObjsRigidBody.useGravity = (false);
        //gameObjsRigidBody.isKinematic = (true);

        //bullet.AddComponent<Rigidbody>().useGravity = (false);

        //gameObjectsHingeJoint.connectedBody = gameObjsRigidBody;
        //gameObjsRigidBody.useGravity = (false);
        //gameObjsRigidBody.isKinematic = (true);

     */
}
