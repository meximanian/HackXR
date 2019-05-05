using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollision : MonoBehaviour
{
    GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.Find("shield");
    }

    // Update is called once per frame
    void Update()
    {
      
        if (shieldFly.shieldThrow)
        {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), shield.GetComponent<Collider>(),false);
        }
        else
        {
           
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), shield.GetComponent<Collider>());
           // Debug.Log(shieldFly.shieldThrow);
        }
    }
}
