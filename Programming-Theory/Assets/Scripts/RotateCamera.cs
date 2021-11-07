using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Use the 'a' and 'd' keys or left and right arrow keys to rotate the camera around the island
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.left, verticalInput * rotationSpeed * Time.deltaTime, Space.World);
    }
}
