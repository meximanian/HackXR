using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isLeft;
    int randomNum;
    bool hit = false;
    bool hasHit = false;
    float vibrateRefractory = 0.2f;
    float hitTime = 0.0f;
    bool canHit = true;
    AudioSource source;
    public AudioClip punch1, punch2, punch3, wall;
    string hitTarget; 
    void Start()
    {
        source = transform.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit && hitTime < vibrateRefractory)
        {
            randomNum = Random.Range(0, 3);

            if (!hasHit)
            {
                if (hitTarget == "fullWall")
                {
                    source.PlayOneShot(wall);
                }
                else
                {


                    if (randomNum == 0)
                    {
                        source.PlayOneShot(punch1);
                    }
                    if (randomNum == 1)
                    {
                        source.PlayOneShot(punch2);
                    }
                    if (randomNum == 2)
                    {
                        source.PlayOneShot(punch3);
                    }
                }
                
                hasHit = true;
            }
            if (isLeft)
                OVRInput.SetControllerVibration(0.5f, 1.0f, OVRInput.Controller.LTouch);
            else
                OVRInput.SetControllerVibration(0.5f, 1.0f, OVRInput.Controller.RTouch);
            hitTime += Time.deltaTime;
        }
        else
        {
            if (isLeft)
                OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.LTouch);
            else
                OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.RTouch);
            hit = false;
            hasHit = false;
            hitTime = 0.0f;
        }
        //if (!canHit)
        //{
        //    if(isLeft)
        //        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        //    else
        //        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        //    hitTime += Time.deltaTime;
        //    if (hitTime > vibrateRefractory)
        //    {
        //        canHit = true;
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
        hitTarget = collision.gameObject.tag;
        Debug.Log(hitTarget);

        if (collision.gameObject.tag == "droid")
        {
            if (playerCollider.blocking)
            {
             HealthBoss.unblockable = true;
             HealthBoss.damaged++;
                
            }
            
        }
        //if (canHit)
        //{
        //    canHit = false;
        //    if (isLeft)
        //    {
        //        OVRInput.SetControllerVibration(.5f, 1, OVRInput.Controller.LTouch);

        //    }
        //    else
        //    {
        //        OVRInput.SetControllerVibration(.5f, 1, OVRInput.Controller.RTouch);
        //    }
        //}
    }
}
