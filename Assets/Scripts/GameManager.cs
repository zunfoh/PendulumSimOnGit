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
    GameObject rodTest;
    GameObject hrBar;
    GameObject ballTest;
    Rigidbody rodRB;
    Rigidbody hrBarRB;
    HingeJoint rodHingeJoint;
    FixedJoint ballFJ;
    float refY;
    float refYforBall;
    //int rodCount;


    // Start is called before the first frame update
    void Start()
    {
        //rodTest = new GameObject[rodCount];

        //rodCount = 3;

        SetBar();

        SetRod();

        SetSphere();

        
    }

    private void SetSphere()
    {
        refYforBall = refY - rodTest.transform.localScale.y*2 - rodTest.transform.localScale.y / 4;
        ballTest = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ballTest.transform.position = new Vector3(hrBar.transform.position.x, refYforBall, hrBar.transform.position.z);

        ballFJ = ballTest.AddComponent<FixedJoint>();
        ballFJ.connectedBody = rodRB;
    }

    private void SetRod()
    {
        refY = hrBar.transform.position.y - hrBar.transform.localScale.x / 2;

        
            //refY = hrBar.transform.position.y - hrBar.transform.localScale.y / 2; //first
            //refY = hrBar.transform.position.y - hrBar.transform.localScale.x / 2;//when hrBar as cylinter rotate to 90"


            rodTest= GameObject.CreatePrimitive(PrimitiveType.Capsule);
            rodTest.transform.localScale = new Vector3(0.5f, 1.8f, 0.5f);
            //rodForTest.transform.position = new Vector3(hrBar.transform.position.x, refY - rodForTest.transform.localScale.y, hrBar.transform.position.z);
            rodTest.transform.position = new Vector3(hrBar.transform.position.x, refY - rodTest.transform.localScale.y, hrBar.transform.position.z);
            //rodForTest.transform.position = new Vector3(hrBar.transform.position.x, hrBar.transform.position.y, hrBar.transform.position.z);


            //localScaleY is twice length for cyclinder and cpsusle,

            //rodForTest.transform.Rotate(40.0f, 0.0f, 0.0f, Space.Self);

            rodHingeJoint = rodTest.AddComponent<HingeJoint>();
            rodHingeJoint.connectedBody = hrBarRB;
            //rodHingeJoint.autoConfigureConnectedAnchor = (false);

            rodRB = rodTest.GetComponent<Rigidbody>();
            rodRB.useGravity = (false);
            rodRB.isKinematic = (true);//could be a trigger when "false" is like real physics
        
    }

    private void SetBar()
    {
        hrBar = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        hrBar.transform.localScale = new Vector3(1f, 4f, 1f);
        hrBar.transform.Rotate(90f, 0f, 0f, Space.Self);
        hrBar.transform.position = new Vector3(0f, 20f, 0.5f);
        hrBarRB = hrBar.AddComponent<Rigidbody>();
        hrBarRB.useGravity = (false);
        hrBarRB.isKinematic = (true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("s"))
        {
            rodRB.useGravity = (true);
        }

        if (Input.GetKeyUp("k"))
        {
            rodRB.isKinematic = (false);
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
