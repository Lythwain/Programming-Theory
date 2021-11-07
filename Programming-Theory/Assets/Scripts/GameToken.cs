using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToken : MonoBehaviour
{
    //Types
    public enum TokenType {Default = 0, Cube = 1, Sphere = 2};

    //internal variables
    private float factor = 200.0f;
    private string m_name;
    protected Rigidbody rb;
    private TokenType m_tokenType;
    public GameObject body; 

    //accessors
    public string Name 
    {
        //ENCAPSULATION
        get { return m_name; } 
        set { m_name = value; } 
    }
    public TokenType Token { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.Token = TokenType.Default;
        m_name = "Empty";
         SetBody();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        rb.AddForce(Vector3.forward * 0.1f * Time.deltaTime, ForceMode.Impulse);
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.transform.Rotate(new Vector3(0.0f, Random.Range(-1, 1) * Time.deltaTime, 0.0f));
    }
    public virtual void SetBody()
    {
        //INHERITANCE
        body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        body.transform.position = GameObject.Find("StartPoint").transform.position;

        rb = body.AddComponent<Rigidbody>();
        rb.mass = 1.0f;
        rb.useGravity = true;
        body.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        Material mat = new Material(GameObject.Find("Cylinder").GetComponent<MeshRenderer>().material);
        mat.color = Color.cyan;
        body.GetComponent<MeshRenderer>().material = mat;

        body.AddComponent<SphereCollider>();
    }
}
