using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armmovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            rb.velocity = transform.right * speed;
            Debug.Log("Button us");
        }
    }
}
