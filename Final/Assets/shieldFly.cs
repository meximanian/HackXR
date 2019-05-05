using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldFly : MonoBehaviour
{
    bool shieldThrow = false;
    GameObject player;
    GameObject playerLeftArm;
    GameObject shield;
    Vector3 shieldPosition1;
    Vector3 shieldPosition2;
    Vector3 shieldForward1;
    Vector3 shieldForward2;
    Vector3 shieldForwardAverage;

    float startTime;
    bool countTimeRN = true;
    float distanceChanged;


    float waitForALittle;
    bool shieldBacking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OVRCameraRig");
        playerLeftArm = GameObject.Find("LeftHandAnchor");
        shield = GameObject.Find("shield");
        shield.transform.position = playerLeftArm.transform.position;
        waitForALittle = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - waitForALittle > 1)
        {
            if (shield.transform.up.y > 0.85f && shield.transform.up.y < 1f)
            {
                if (countTimeRN)
                {
                    startTime = Time.time;
                    shieldPosition1 = playerLeftArm.transform.position;
                    shieldForward1 = shield.transform.forward;
                    countTimeRN = false;

                }
                if (Time.time - startTime > 0.1f)
                {
                    countTimeRN = true;
                }

                if (!shieldThrow)
                {
                    shieldPosition2 = playerLeftArm.transform.position;
                    Debug.Log("shieldPosition1: " + shieldPosition1);
                    Debug.Log("shieldPosition2: " + shieldPosition2);
                    distanceChanged = Vector3.Distance(shieldPosition1, shieldPosition2);
                    Debug.Log("distance: " + distanceChanged);
                    if (distanceChanged > 0.15f)
                    {
                        shield.transform.parent = null;
                        shieldForward2 = shield.transform.forward;
                        //shieldForwardAverage = (shieldForward1 + shieldForward1) / 2;
                        shield.GetComponent<Rigidbody>().velocity = shieldForward2 * 10;
                        //shield.transform.position = n;
                        shieldThrow = true;
                    }

                }
                else
                {
                    //if (shield.transform.position.y < 1)
                    //{
                    //    shield.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    //    shield.transform.parent = playerLeftArm.transform;
                    //    shield.transform.position = playerLeftArm.transform.position;
                    //    shield.transform.localRotation = Quaternion.Euler(90, 0, 90);
                    //    shield.transform.localPosition = new Vector3(0, 0, 0);
                    //    shieldThrow = false;
                    //    shieldBacking = false;
                    //    //waitForALittle = Time.time;
                    //}
                    if (Vector3.Distance(shield.transform.position, playerLeftArm.transform.position) > 15 || shield.transform.position.y < 1)
                    {
                        shield.GetComponent<Rigidbody>().velocity = shieldForward2 * -10;
                        shieldBacking = true;
                            //Debug.Log("direction: " + Vector3.Distance(shield.transform.position, playerLeftArm.transform.position));
                    }
                    if (shieldBacking)
                    {
                        if (Vector3.Distance(shield.transform.position, playerLeftArm.transform.position) < 0.5f)
                        {
                            shield.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                            shield.transform.parent = playerLeftArm.transform;
                            shield.transform.position = playerLeftArm.transform.position;
                            shield.transform.localRotation = Quaternion.Euler(90, 0, 90);
                            shield.transform.localPosition = new Vector3(0, 0, 0);
                            shieldThrow = false;
                            shieldBacking = false;
                            //waitForALittle = Time.time;
                        }

                        //if (Vector3.Distance(shield.transform.position, playerleftarm.transform.position) < 2f)
                        ////{
                        

                        //}
                    }
                }

                //Debug.Log("Time: "+(Time.time - startTime));

                //Debug.Log("shieldPosition2: " + shieldPosition2);
                

                //Debug.Log(shield.GetComponent<Rigidbody>().);

                //shield.transform.rotation = playerLeftArm.transform.rotation;
                //Debug.Log("djfoejfojeojf: "+shield.transform.up.y);
            }


        }


    }
}
