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
    public GameObject soundManager;
    GameObject[] rodArray;
    GameObject[] sphereArray;
    GameObject mainBar;

    AudioSource colidSoundEff;


    int rodTotal;
    Rigidbody tempRB;//this is declareing, so without "=" !!
    float tempRadius;
    //int rodCount;

    private void Awake()
    {
        //FindObjectOfType<BrAudioManager>().Play("BackGroundMusic");
    }

    // Start is called before the first frame update
    void Start()
    {
       

        rodTotal = 3;
        rodArray = new GameObject[rodTotal];
        tempRadius = 0.4f;
        //rodTest = new GameObject[rodCount];

        
        sphereArray = new GameObject[rodTotal];


        float xGap = 0.4f;
        float rodXPos;

        //GameObject tempObject;
        //Transform tempTransform;

        CreateMainBar();
        rodXPos = mainBar.transform.position.x - mainBar.transform.localScale.x / 2 + xGap;

        for (int i = 0; i < rodTotal; i++)
        {

            rodArray[i] = SetRod(rodXPos);

            sphereArray[i] = SetSphere(rodArray[i], rodXPos, i);

            //sphereArray[i].AddComponent<AudioSource>();

            rodXPos += xGap;

        }

        //sphereArray[0].GetComponent<CollisonSoundTest>

        
    }

    

    private void CreateMainBar()
    {

        mainBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mainBar.transform.localScale = new Vector3(20, 1, 1);
        mainBar.transform.position = new Vector3(5.8f, 20, 0);
    }

    //private void SetSphere(GameObject hrBar)
    private GameObject SetSphere(GameObject refRod, float xPos, int indx)

    {
        GameObject refBall;

        Rigidbody rodRB;
        FixedJoint ballFJ;
        float refYforBall;
        float refY;

        //AudioSource colidSoundEff;


        refY = mainBar.transform.position.y - mainBar.transform.localScale.y / 2;  // y position of bottom of a bar 
        rodRB = refRod.GetComponent<Rigidbody>();

        //refYforBall = refY - refRod.transform.localScale.y * 2 - refRod.transform.localScale.y / 4;
        refYforBall = refY - refRod.transform.localScale.y * 2;
        refBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        refBall.transform.localScale = new Vector3(tempRadius, tempRadius, tempRadius);

        refBall.transform.position = new Vector3(xPos, refYforBall - tempRadius / 2.0f, mainBar.transform.position.z);


        ballFJ = refBall.AddComponent<FixedJoint>();

        ballFJ.connectedBody = rodRB;

        refBall.AddComponent<CollisonSoundTest>();
        refBall.GetComponent<CollisonSoundTest>().index = indx;
        refBall.GetComponent<CollisonSoundTest>().audioManager = soundManager; 

        //colidSoundEff = refBall.AddComponent<AudioSource>();
        //colidSoundEff.clip= Resources.Load("AudioFiles/metalSou", typeof(AudioClip)) as AudioClip;
        //colidSoundEff.playOnAwake = (false);



        return refBall;
    }

    //private void SetRod(GameObject hrBar)
    //private void SetRod(Transform hrBar)//this is the main focus//private GameObject SetRod
    private GameObject SetRod(float xPos)

    {
        GameObject refRod;
        Rigidbody rodRB;
        Rigidbody hrBarRB;
        HingeJoint rodHingeJoint;
        float refY;

        refY = mainBar.transform.position.y - mainBar.transform.localScale.y / 2;

        //refY = hrBar.transform.position.y - hrBar.transform.localScale.y / 2; //first
        //refY = hrBar.transform.position.y - hrBar.transform.localScale.x / 2;//when hrBar as cylinter rotate to 90"

        refRod = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        refRod.transform.localScale = new Vector3(0.02f, 1.8f, 0.02f);
        //rodForTest.transform.position = new Vector3(hrBar.transform.position.x, refY - rodForTest.transform.localScale.y, hrBar.transform.position.z);
        refRod.transform.position = new Vector3(xPos, refY - refRod.transform.localScale.y, mainBar.transform.position.z);
        //rodForTest.transform.position = new Vector3(hrBar.transform.position.x, hrBar.transform.position.y, hrBar.transform.position.z);

        //localScaleY is twice length for cyclinder and cpsusle,


        rodHingeJoint = refRod.AddComponent<HingeJoint>();
        hrBarRB = mainBar.GetComponent<Rigidbody>();

        rodHingeJoint.connectedBody = hrBarRB;
        rodHingeJoint.axis = new Vector3(0f, 0f, 1f);
        rodHingeJoint.autoConfigureConnectedAnchor = (false);
        rodHingeJoint.connectedAnchor = new Vector3(xPos, refY, mainBar.transform.position.z);

        rodRB = refRod.GetComponent<Rigidbody>();
        rodRB.useGravity = (true);//turn it on, then it can swin
        rodRB.isKinematic = (false);//could be a trigger when "false" is like real physics

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
            for (int i = 0; i < rodTotal; i++)
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
        }

        if (Input.GetKeyUp("f"))
        {
           
            tempRB = sphereArray[0].GetComponent<Rigidbody>();//it is defining, and use "="!!
            tempRB.isKinematic = (false);
            tempRB.AddForce(new Vector3(-3, 0, 0), ForceMode.Impulse);




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
