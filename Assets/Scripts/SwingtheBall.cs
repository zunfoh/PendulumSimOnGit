using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingtheBall : MonoBehaviour
{
    float swingSpeed = 0.1f;

    

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0f, zDirection);

        transform.position += moveDirection * swingSpeed;
    }
}
