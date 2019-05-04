using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitCounter = 0;

    public Transform control;
    public GameObject player;
    Vector3 forward;
    Vector3 controllerfwd;

    // Update is called once per frame

    void Start()
    {
         forward = player.transform.forward;
           

    }

    // Update is called once per frame
    void Update()
    {
        controllerfwd = control.forward;

        // Debug.Log(Vector3.Dot(forward, controllerfwd));
       // Debug.Log(Vector3.Distance(forward, controllerfwd));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            hitCounter++;
            Debug.Log(hitCounter);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fullWall")
        {
           if((Vector3.Distance(forward, controllerfwd) > 1.0f)){
                Debug.Log("blocked");

            }
            else
            {
                Debug.Log("NOT blocked");
            }
        }
    }
}
