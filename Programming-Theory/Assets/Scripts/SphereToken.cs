using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereToken : GameToken
{
    public override void Move()
    {
        //// POLYMORPHISM
        rb.AddForce(Vector3.forward * 0.1f * Time.deltaTime, ForceMode.Impulse);
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.transform.Rotate(new Vector3(0.0f, Random.Range(-1, 1) * Time.deltaTime, 0.0f));
    }
    public override void SetBody()
    {
        //INHERITANCE (of variable "body")
        body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        body.transform.position = GameObject.Find("StartPoint").transform.position + Vector3.forward * 3;

        //ABSTRACTION
        AddRigidBody();

        //ABSTRACTION
        AddMaterial();
    }
    private void AddMaterial()
    {
        Material mat = new Material(GameObject.Find("Cylinder").GetComponent<MeshRenderer>().material);
        mat.color = Color.green;
        body.GetComponent<MeshRenderer>().material = mat;
    }
    private void AddRigidBody()
    {
        rb = body.AddComponent<Rigidbody>();
        rb.mass = 1.0f;
        rb.useGravity = true;
        body.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
