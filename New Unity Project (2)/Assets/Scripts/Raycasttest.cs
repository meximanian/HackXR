using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Raycasttest : MonoBehaviour {
  
 
    
    
    
  
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
       

       


        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) == 0.0f && continuousMotion)
        {
       
            stored = false;
        }
        //////////////////////////////              WALKING            /////////////////////////////
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.0f && continuousMotion)
        {
            if (!stored)
            {
                initialPos.x = transform.localPosition.x;
                initialPos.z = transform.localPosition.z;
                if (superman)
                {
                    initialPos.y = transform.localPosition.y;
                }
                initialRot.Set(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
                stored = true;
            }
           
            newRot.Set(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
            
            Quaternion diff = newRot * Quaternion.Inverse(initialRot);

   
            //{
            //    diff = Quaternion.AngleAxis(170, Vector3.up);
            
            Debug.Log(diff.eulerAngles.y);


            Quaternion finRot = (Quaternion.Slerp(transform.root.transform.rotation, transform.root.transform.rotation * diff, 0.01f));
            transform.root.transform.rotation = finRot;
            if (!superman)
            {
                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0f, transform.root.transform.rotation.eulerAngles.y, 0f));
            }
            //timeCount = timeCount + Time.deltaTime;





            //////////////////POSITION///////////////////
            Vector3 pos;
            Vector3 pos2;
            Vector3 pos3 = transform.localPosition;
            Quaternion diff2 = transform.rotation * Quaternion.Inverse(transform.localRotation);

               
            pos = transform.localPosition - initialPos;
            //pos = Vector3.Normalize(pos);


























            // pos = transform.rotation * (pos * 10);

            pos = diff2 * (pos * 10);
            
            pos2 = transform.root.transform.position;
            
            pos2 = pos2 + (pos * Time.deltaTime); 
            if(!superman)
            pos2.y = transform.root.transform.position.y;
            transform.root.transform.position = pos2;

           




        }

        


        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            if (!superman && continuousMotion)
            {
                superman = true;
               

            }
            else if(superman && continuousMotion)
            {
                superman = false;
               
            }
            
        }

    }



}
