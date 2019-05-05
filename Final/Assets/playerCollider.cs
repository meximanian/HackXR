using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitCounter = 0;
    public static bool blocking = false;
    public Transform leftControl;
    public Transform rightControl;
    public GameObject player;
    Vector3 forward;
    Vector3 controllerfwdLeft;
    Vector3 controllerfwdRight;
    public AudioClip crash1, crash2, crash3;
    AudioSource source;

    // Update is called once per frame

    void Start()
    {
         forward = player.transform.forward;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        controllerfwdLeft = leftControl.forward;
        controllerfwdLeft = rightControl.forward;

        // Debug.Log(Vector3.Dot(forward, controllerfwd));
        // Debug.Log(Vector3.Distance(forward, controllerfwd));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            hitCounter++;
            HealthBoss.damaged++;
            Debug.Log(hitCounter);
            source.PlayOneShot(crash1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fullWall")
        {
           if((Vector3.Distance(forward, controllerfwdLeft) > 1.0f) && (Vector3.Distance(forward, controllerfwdLeft) > 1.0f))
            {
                Debug.Log("blocked");
                blocking = true;
              

            }
            else
            {
                Debug.Log("NOT blocked");
                blocking = false;
                HealthBoss.damaged++;
                source.PlayOneShot(crash2);
            }
        }

        if (other.gameObject.tag == "droid")
        {

            HealthBoss.unblockable = true;
            HealthBoss.damaged++;
            source.PlayOneShot(crash3);
        }
    }
}
