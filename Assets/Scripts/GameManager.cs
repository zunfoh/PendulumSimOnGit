using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //float swingSpeed = 0.1f;
    GameObject sphereForTest;
    GameObject rodForTest;
    GameObject hrBar;


    // Start is called before the first frame update
    void Start()
    {
        hrBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hrBar.transform.localScale = new Vector3(1f, 1f, 4f);
        hrBar.transform.position = new Vector3(0f, 1.5f, 0.5f);
        Rigidbody hrBarsRigidbody = hrBar.AddComponent<Rigidbody>();
        hrBarsRigidbody.useGravity = (false);
        hrBarsRigidbody.isKinematic = (true);



        rodForTest = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        rodForTest.transform.localScale = new Vector3(0.5f, 0.9f, 0.5f);
        HingeJoint rodHingeJoint = rodForTest.AddComponent<HingeJoint>();
        rodHingeJoint.connectedBody = hrBarsRigidbody;

        Rigidbody rodRidbody = rodForTest.GetComponent<Rigidbody>();
        rodRidbody.useGravity = (false);
        rodRidbody.isKinematic = (true);//could be a trigger when "false" is like real physics


        sphereForTest = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereForTest.transform.position = new Vector3(0.01f, -1.72f, 0.26f);
        HingeJoint sphereHingeJoint = sphereForTest.AddComponent<HingeJoint>();
        sphereHingeJoint.connectedBody = rodRidbody;


        //Rigidbody gameObjsRigidBody = sphereForTest.AddComponent<Rigidbody>();
        //gameObjsRigidBody.useGravity = (false);
        //gameObjsRigidBody.isKinematic = (true);

        //bullet.AddComponent<Rigidbody>().useGravity = (false);

        //gameObjectsHingeJoint.connectedBody = gameObjsRigidBody;
        //gameObjsRigidBody.useGravity = (false);
        //gameObjsRigidBody.isKinematic = (true);
    }

    // Update is called once per frame
    void Update()
    {
        

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

     */
}
