using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Random;

public class obstacleGenerator : MonoBehaviour
{
    int randomNum;
    GameObject obstacle;
    GameObject enemy;
    bool firstTen = true;
    public GameObject plane;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 80; i++)
        {
            randomNum = Random.Range(0, 5);
            if (i > 10)
            {
                firstTen = false;
            }
            if (randomNum == 0 || randomNum == 5)
            {

                GameObject prefab2 = Resources.Load("red") as GameObject;
                enemy = Instantiate(prefab2) as GameObject;
                enemy.transform.position = new Vector3(0, 0.0f, (i * 20) + 10);
                enemy.transform.parent = plane.transform;
                if (firstTen == true)
                {
                    GameObject prefab1 = Resources.Load("FIGHT") as GameObject;
                    obstacle = Instantiate(prefab1) as GameObject;
                    obstacle.transform.position = new Vector3(3.19f, 1.12f, (i * 20) + 10);
                    obstacle.transform.parent = plane.transform;
                }
                //gameobject prefab = resources.load("target") as gameobject;
                //obstacle = instantiate(prefab) as gameobject;
                //obstacle.transform.position = new vector3(0, 1.6f, -90 + i * 7);
            }
            else if (randomNum == 1)
            {
                GameObject prefab = Resources.Load("LeftWall") as GameObject;
                obstacle = Instantiate(prefab) as GameObject;
                obstacle.transform.position = new Vector3(1.422f, 0.07f, i * 20);
                obstacle.transform.parent = plane.transform;
                if (firstTen == true)
                {
                    GameObject prefab1 = Resources.Load("RIGHT CANVAS") as GameObject;
                    obstacle = Instantiate(prefab1) as GameObject;
                    obstacle.transform.position = new Vector3(6.3f, 0.67f, i * 20);
                    obstacle.transform.parent = plane.transform;
                }
            }
            else if (randomNum == 2 || randomNum == 3)
            {
                GameObject prefab = Resources.Load("RightWall") as GameObject;
                obstacle = Instantiate(prefab) as GameObject;
                obstacle.transform.position = new Vector3(3.06f, 0.07f, i * 20);
                obstacle.transform.parent = plane.transform;
                if (firstTen == true)
                {
                    GameObject prefab1 = Resources.Load("LEFT CANVAS") as GameObject;
                    obstacle = Instantiate(prefab1) as GameObject;
                    obstacle.transform.position = new Vector3(6.3f, 1.55f, i * 20);
                    obstacle.transform.parent = plane.transform;
                }
            }
            else if (randomNum == 4)
            {
                GameObject prefab = Resources.Load("fullWall") as GameObject;
                obstacle = Instantiate(prefab) as GameObject;
                obstacle.transform.position = new Vector3(1.442f, 0.07f, i * 20);
                obstacle.transform.parent = plane.transform;

                if (firstTen == true)
                {
                    GameObject prefab1 = Resources.Load("BLOCK Variant") as GameObject;
                    obstacle = Instantiate(prefab1) as GameObject;
                    obstacle.transform.position = new Vector3(3.19f, 1.16f, (i * 20) - 5);
                    obstacle.transform.parent = plane.transform;
                }
            }

        }

        //GameObject player = GameObject.Find("Player");
        //player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
    }

    void firstTenBlocks()
    {

    }

    // Update is called once per frame
    void Update()
    {




    }
}