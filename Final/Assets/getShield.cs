using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getShield : MonoBehaviour
{
    GameObject getthisShield;
    GameObject shield;
    GameObject boss;
    public GameObject text1;
    public GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        getthisShield = GameObject.Find("getShield");
        shield = GameObject.Find("shield");
        shield.SetActive(false);
        boss = GameObject.Find("Boss");
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        shield.SetActive(true);
        boss.SetActive(true);
        text1.SetActive(true);
        text2.SetActive(true);
        Destroy(getthisShield);
        



    }
}
