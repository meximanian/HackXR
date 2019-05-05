using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    private LineRenderer laserLine;
    GameObject boss;
    GameObject shield;
    Vector3 shieldForward;
    public static Vector3 shieldToBossDir;
    public static bool aimOk;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        shield = GameObject.Find("shield");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (!shieldFly.shieldThrow)
        {
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, transform.position);
            shieldForward = shield.transform.forward;
            shieldToBossDir = Vector3.Normalize(boss.transform.position + new Vector3(0, 1.5f, 0) - shield.transform.position);
            float shieldBossDot = Vector3.Dot(shieldForward, shieldToBossDir);
            //Debug.Log("shieldForward" + shieldForward);
            //Debug.Log("shieldToBossDir" + shieldToBossDir);
            //Debug.Log("shieldBossAngle" + shieldBossDot);
            if (shieldBossDot > 0.95f)
            {
                laserLine.SetPosition(1, boss.transform.position + new Vector3(0, 1.5f, 0));
                aimOk = true;
            }
            else
            {
                laserLine.SetPosition(1, transform.position + transform.TransformDirection(Vector3.forward) * 20);
                aimOk = false;
            }
        }
        else
        {
            laserLine.positionCount = 0;
        }

        //Debug.Log("dshfiehofuwfho: "+Vector3.Distance(boss.transform.position + new Vector3(0, 1.5f, 0), shield.transform.position));

    }
}
