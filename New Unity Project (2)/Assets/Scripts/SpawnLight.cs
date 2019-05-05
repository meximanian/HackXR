using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLight : MonoBehaviour
{
    private GameObject player;
    private float xdistance1;
    private float xdistance2;
    private float ydistance;
    private float zdistance;
    public GameObject Light1;
    public GameObject Light2;
    private float timeStamp;
    public float cooldown = 1.5f;

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("player");
        xdistance1 = 4.0f;
        xdistance2 = -4.0f;
        ydistance = 5.0f;
        zdistance = player.transform.position.z + 5;

        if(timeStamp <= Time.time)
        {
            Instantiate(Light1, new Vector3(xdistance1, ydistance, zdistance), transform.rotation);
            Instantiate(Light2, new Vector3(xdistance2, ydistance, zdistance), transform.rotation);
            timeStamp = Time.time + cooldown;
            Debug.Log("Yaes");
        }
    }
}
