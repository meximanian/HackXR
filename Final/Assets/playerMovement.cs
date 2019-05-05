using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plane.transform.position -= plane.transform.forward * Time.deltaTime * fistScript.speed * 10 * fistScript.boost;
    }
}
