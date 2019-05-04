using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Transform other;
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            Vector3 forward = player.transform.forward;
            Vector3 controllerfwd = other.right;

            Debug.Log(Vector3.Dot(forward, controllerfwd));
        }
    }
}
