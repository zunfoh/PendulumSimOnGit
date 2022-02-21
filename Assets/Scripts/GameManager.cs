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
    GameObject[] rodArray;
    int rodTotal;
    Rigidbody tempRB;//this is declareing, so without "=" !!
    //int rodCount;


    // Start is called before the first frame update
    void Start()
    {
        rodTotal = 5;
        rodArray = new GameObject[rodTotal];
       
        //rodTest = new GameObject[rodCount];

        //rodCount = 3;
        float xPos = 0;
        float xGap = 1.5f;
        //GameObject tempObject;
        Transform tempTransform;



        for (int i = 0; i < rodTotal; i++)
        {
            tempTransform = SetBar(xPos); //Transform = Transform, why is that? ya why Transform?

            rodArray[i] = SetRod(tempTransform);

            SetSphere(tempTransform, rodArray[i]);

            xPos += xGap;

        }


    }

    //private void SetSphere(GameObject hrBar)
    private void SetSphere(Transform hrBar, GameObject refRod)

    {
        GameObject refBall;

        Rigidbody rodRB;
        FixedJoint ballFJ;
        float refYforBall;
        float refY;


        refY = hrBar.transform.position.y - hrBar.transform.localScale.x / 2;

        rodRB = refRod.GetComponent<Rigidbody>();

        refYforBall = refY - refRod.transform.localScale.y * 2 - refRod.transform.localScale.y / 4;
        refBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        refBall.transform.position = new Vector3(hrBar.transform.position.x, refYforBall, hrBar.transform.position.z);

        ballFJ = refBall.AddComponent<FixedJoint>();

        ballFJ.connectedBody = rodRB;
    }

    //private void SetRod(GameObject hrBar)
    //private void SetRod(Transform hrBar)//this is the main focus//private GameObject SetRod
    private GameObject SetRod (Transform hrBar)

    {
        GameObject refRod;
        Rigidbody rodRB;
        Rigidbody hrBarRB;
        HingeJoint rodHingeJoint;
        float refY;



        refY = hrBar.transform.position.y - hrBar.transform.localScale.x / 2;

        //refY = hrBar.transform.position.y - hrBar.transform.localScale.y / 2; //first
        //refY = hrBar.transform.position.y - hrBar.transform.localScale.x / 2;//when hrBar as cylinter rotate to 90"


        refRod = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        refRod.transform.localScale = new Vector3(0.5f, 1.8f, 0.5f);
        //rodForTest.transform.position = new Vector3(hrBar.transform.position.x, refY - rodForTest.transform.localScale.y, hrBar.transform.position.z);
        refRod.transform.position = new Vector3(hrBar.transform.position.x, refY - refRod.transform.localScale.y, hrBar.transform.position.z);
        //rodForTest.transform.position = new Vector3(hrBar.transform.position.x, hrBar.transform.position.y, hrBar.transform.position.z);

        //localScaleY is twice length for cyclinder and cpsusle,


        rodHingeJoint = refRod.AddComponent<HingeJoint>();
        hrBarRB = hrBar.GetComponent<Rigidbody>();

        rodHingeJoint.connectedBody = hrBarRB;
        rodHingeJoint.axis = new Vector3(0f, 0f, 1f);
        //rodHingeJoint.autoConfigureConnectedAnchor = (false);

        rodRB = refRod.GetComponent<Rigidbody>();
        rodRB.useGravity = (false);//turn it on, then it can swin
        rodRB.isKinematic = (true);//could be a trigger when "false" is like real physics

        return refRod;

    }

    private Transform SetBar(float xPos) //still don't really know why use Transform class instead
    //private GameObject SetBar(float xPos)
    {
        GameObject hrBar;
        Rigidbody hrBarRB;

        //Transform hrBar;

        hrBar = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        hrBar.transform.localScale = new Vector3(1f, 4f, 1f);
        hrBar.transform.Rotate(90f, 0f, 0f, Space.Self);
        hrBar.transform.position = new Vector3(xPos, 20f, 0.5f);
        hrBarRB = hrBar.AddComponent<Rigidbody>();
        hrBarRB.useGravity = (false);
        hrBarRB.isKinematic = (true);

        return hrBar.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("s"))
        {
            for (int i = 0; i<rodTotal; i++)
            {
                tempRB = rodArray[i].GetComponent<Rigidbody>();//it is defining, and use "="!!
                tempRB.useGravity = (true);
            }
        }

        if (Input.GetKeyUp("k"))
        {
            for (int i = 0; i < rodTotal; i++)
            {
                tempRB = rodArray[i].GetComponent<Rigidbody>();//it is defining, and use "="!!
                tempRB.isKinematic = (false);
            }
            //rodRB.isKinematic = (false);
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
