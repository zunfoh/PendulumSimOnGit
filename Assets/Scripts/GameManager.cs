using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float swingSpeed = 0.1f;
    GameObject sphereForTest;


    // Start is called before the first frame update
    void Start()
    {
        GameObject rodForTest = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        HingeJoint gameObjectsHingeJoint = rodForTest.AddComponent<HingeJoint>();

        sphereForTest = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereForTest.transform.position = new Vector3(-0.1f, -0.5f, -1f);
        Rigidbody gameObjsRigidBody = sphereForTest.AddComponent<Rigidbody>();
        gameObjsRigidBody.useGravity = (false);
        gameObjsRigidBody.isKinematic = (true);

        //bullet.AddComponent<Rigidbody>().useGravity = (false);
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0f, zDirection);

        sphereForTest.transform.position += moveDirection * swingSpeed;

    }

    /* 
     * GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
     * Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
     * gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.

     */
}
