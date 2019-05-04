using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class fistScript : MonoBehaviour
{


    public static float speed;
    public static float boost;



    bool continuousMotion = true;
    bool stored = false;
    bool superman = false;
    bool teleArrow = true;
    float heldDownTime;
    float dist;


    Vector3 lastPosition;
    Vector3 initialPos;
    Quaternion initialRot;
    Quaternion newRot;
    Quaternion newRot2;
    private float timeCount = 0.0f;


    int colorCounter = 0;

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        speed = 1.0f;
        boost = 1.0f;
        speed -= OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);
        
        boost += OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch);


        RaycastHit hit = new RaycastHit();


        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 5000))
        {






        }






        //if (OVRInput.GetUp(OVRInput.RawButton.A)){
        //    heldDownTime = Time.deltaTime;
        //    desk = Instantiate(deskPre) as GameObject;

        //    desk.transform.position = (transform.position + (transform.TransformDirection(Vector3.forward).normalized * 2));
        //}


        /////CHAIR///////





       

    }



}
