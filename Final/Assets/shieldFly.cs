using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldFly : MonoBehaviour
{
    public static bool shieldThrow = false;
    public GameObject eye;
    public GameObject fistL;
    public GameObject fistR;
    public GameObject plane;
    public GameObject youWin;
    GameObject player;
    GameObject playerLeftArm;
    GameObject shield;
    GameObject playerHead;
    GameObject boss;
    GameObject cube;
    GameObject android;
    Transform bossOrg;
    Vector3 shieldPosition1;
    Vector3 shieldPosition2;
    Vector3 shieldForward1;
    Vector3 shieldForward2;
    Vector3 shieldForwardAverage;
    Rigidbody shieldRigidBody;

    int bossHealth = 2;

    float startTime;
    bool countTimeRN = true;
    float distanceChanged;

    int num1, num2, num3;


    float waitForALittle;
    bool shieldBacking = false;
    bool hitedBoss = false;
    float timeReset;
    int pre1;
    int rdn1,rdn2,rdn3;

    float anotherTimer;
    int bossXChange;
    Vector3 orgShieldPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OVRCameraRig");
        playerLeftArm = GameObject.Find("LeftHandAnchor");
        playerHead = GameObject.Find("CenterEyeAnchor");
        shield = GameObject.Find("shield");
        orgShieldPos = shield.transform.localPosition;
        Debug.Log("orgShieldPos:" + orgShieldPos);
        boss = GameObject.Find("Boss");

        Physics.IgnoreCollision(transform.GetComponent<Collider>(), eye.GetComponent<Collider>());
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), fistL.GetComponent<Collider>());
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), fistR.GetComponent<Collider>());
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), plane.GetComponent<Collider>());

        //shield.transform.position = playerLeftArm.transform.position + orgShieldPos;
        waitForALittle = Time.time;
        shieldRigidBody = shield.GetComponent<Rigidbody>();
        bossOrg = boss.transform;
        anotherTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("shield.transform.position:" + shield.transform.position);
        if (Time.time - waitForALittle > 1)
        {
            //float temp = Vector3.Dot(shield.transform.up, playerLeftArm.transform.up);
            //Debug.Log("dot: "+temp);
            if (true)//shield.transform.up.y > 0.75f && shield.transform.up.y < 1f
            {
                if (countTimeRN)
                {
                    startTime = Time.time;
                    shieldPosition1 = playerLeftArm.transform.position + orgShieldPos;
                    shieldForward1 = shield.transform.forward;
                    countTimeRN = false;

                }
                if (Time.time - startTime > 0.05f)
                {
                    countTimeRN = true;
                }

                if (!shieldThrow)
                {
                    shieldPosition2 = playerLeftArm.transform.position + orgShieldPos;
                    //Debug.Log("shieldPosition1: " + shieldPosition1);
                    //Debug.Log("shieldPosition2: " + shieldPosition2);
                    distanceChanged = Vector3.Distance(shieldPosition1, shieldPosition2);
                    //Debug.Log("distance: " + distanceChanged);
                    if (distanceChanged > 0.15f)
                    {
                        float position1ToHead = Vector3.Distance(shieldPosition1, playerHead.transform.position);
                        float position2ToHead = Vector3.Distance(shieldPosition2, playerHead.transform.position);
                        if (position2ToHead > position1ToHead)
                        {
                            shield.transform.parent = null;
                            shieldForward2 = shield.transform.forward;
                            //shieldForwardAverage = (shieldForward1 + shieldForward1) / 2;
                            if (RayCastScript.aimOk)
                            {
                                shieldRigidBody.velocity = RayCastScript.shieldToBossDir * 20;
                            }
                            else
                            {
                                shieldRigidBody.velocity = shieldForward2 * 20;
                            }
                            
                            //shield.transform.position = n;
                            shieldThrow = true;
                        }
                        
                    }

                }
                else
                {
                    if (true) //|| shield.transform.position.y < 1
                    {
                        if (shieldRigidBody.angularVelocity != Vector3.zero)
                        {
                            shieldRigidBody.velocity = -shieldForward2 * 15;
                            shieldBacking = true;
                        }
                        if (hitedBoss || Vector3.Distance(shield.transform.position, playerLeftArm.transform.position + orgShieldPos) > 30)// || shieldRigidBody.angularVelocity != Vector3.zero)
                        {
                            var delta =  (playerLeftArm.transform.position + orgShieldPos - shield.transform.position);
                            Debug.Log(delta.sqrMagnitude);

                            if (delta.sqrMagnitude < 50f) { delta = delta*5; }
                            if (delta.sqrMagnitude < .1f) { delta = Vector3.zero; }
                            //else { shieldRigidBody.AddForce(delta * 100); }
                            shieldRigidBody.velocity = delta;


                            //Debug.Log(delta.y);
                            //Debug.Log(Time.time - timeReset);
                            if (hitedBoss && (Time.time - timeReset)<1)
                            {
                                
                                shieldRigidBody.velocity = new Vector3(rdn1, rdn2, rdn3);
                               
                            }
                            else
                            {
                                hitedBoss = false;
                                shieldRigidBody.velocity = delta /* shieldForward2 * -10*/;
                               
                            }
                            

                            shieldBacking = true;
                        }
                        if (!hitedBoss)
                        {
                            timeReset = Time.time;
                            pre1 = Random.Range(0, 2);
                            if (pre1 == 0)
                            {
                                rdn1 = Random.Range(-20, -10);
                                bossXChange = 1;
                            }
                            else
                            {
                                rdn1 = Random.Range(10, 20);
                                bossXChange = -1;
                            }

                            rdn2 = Random.Range(-5, 10);
                            rdn3 = Random.Range(-2, 2);


                        } 

                        //Debug.Log("direction: " + Vector3.Distance(shield.transform.position, playerLeftArm.transform.position));
                    }

                    if (shieldBacking)
                    {

                        shieldRigidBody.angularVelocity = Vector3.zero;
                        if (Vector3.Distance(shield.transform.position, playerLeftArm.transform.position + orgShieldPos) < 0.5f)
                        {
                            shield.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                            shield.transform.parent = playerLeftArm.transform;
                            shield.transform.localPosition = orgShieldPos;
                            shield.transform.localRotation = Quaternion.Euler(90, 0, 90);

                            

                            shieldThrow = false;
                            shieldBacking = false;
                            hitedBoss = false;
                            
                            //waitForALittle = Time.time;
                        }
                    }


                }

                //Debug.Log("Time: "+(Time.time - startTime));

                //Debug.Log("shieldPosition2: " + shieldPosition2);
                

                //Debug.Log(playerLeftArm.transform.position);

                //shield.transform.rotation = playerLeftArm.transform.rotation;
                //Debug.Log("djfoejfojeojf: "+shield.transform.up.y);
            }


        }


        if (!shieldThrow && !shieldBacking)
        { transform.gameObject.GetComponent<CapsuleCollider>().enabled = false; }
        else
        {
            transform.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (!shieldThrow)
        {
            if (collision.gameObject.tag == "droid" )//&& (Time.time - anotherTimer) > 4)
            {
                Physics.IgnoreCollision(transform.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
            }
        }
        else
        {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>(), false);
        }
        //    Debug.Log(shieldThrow);
        //    Debug.Log(collision.gameObject.name);

        //num2 = Random.Range(-10, 10);
        //num3 = Random.Range(150, 300);

        if (collision.gameObject.tag == "Boss")//&& (Time.time - anotherTimer) > 4)
        {
            //shieldRigidBody.AddForce(new Vector3(num1, 0, -2));
            //shieldRigidBody.AddForce(new Vector3(-shield.transform.right.x*300, -shield.transform.right.y, shield.transform.right.z*300));
            //shieldRigidBody.velocity = new Vector3(-3, 0, 0);
            hitedBoss = true;
            




        }

        if (collision.gameObject.tag == "Boss" && (Time.time - anotherTimer) > 1)
        {
            num1 = Random.Range(2, 4) * bossXChange;
            num2 = Random.Range(-2, 4);
            num3 = Random.Range(-2, 2);
            boss.transform.position = bossOrg.position + new Vector3(num1, 0, 0);
            Destroy(GameObject.Find(bossHealth.ToString()));
            bossHealth -= 1;
            //Debug.Log(new Vector3(num1, num2, num3));
            anotherTimer = Time.time;
        }
        //Debug.Log(collision.gameObject.tag);
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}
        //if (collision.relativeVelocity.magnitude > 2)
        //    audioSource.Play();

        if (bossHealth == -1)
        {
            youWin.SetActive(true);
        }
    }
}
