using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Random;

public class obstacleGenerator : MonoBehaviour
{
    int randomNum;
    GameObject obstacle;
    GameObject enemy;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 30; i++)
        {
            randomNum = Random.Range(0, 5);
            
            //if (randomNum == 0 || randomNum == 1)
            //{
            //    GameObject prefab = Resources.Load("LeftWall") as GameObject;
            //    obstacle = Instantiate(prefab) as GameObject;
            //    obstacle.transform.position = new Vector3(3.0f, 0.07f, i * 20);
            //}
            //else if (randomNum == 2 || randomNum == 3)
            //{
            //    GameObject prefab = Resources.Load("RightWall") as GameObject;
            //    obstacle = Instantiate(prefab) as GameObject;
            //    obstacle.transform.position = new Vector3(6.3f, 0.07f, i * 20);
            //}
            if (true)
            {
               GameObject prefab = Resources.Load("fullWall") as GameObject;
               obstacle = Instantiate(prefab) as GameObject;
                obstacle.transform.position = new Vector3(3.19f, 0.07f, i * 20);

                GameObject prefab2 = Resources.Load("red") as GameObject;
                enemy = Instantiate(prefab2) as GameObject;
                enemy.transform.position = new Vector3(0,0, (i * 20) + 10);
            }
            //else if (randomNum == 3)
            //{
            //    GameObject prefab = Resources.Load("target") as GameObject;
            //    obstacle = Instantiate(prefab) as GameObject;
            //    obstacle.transform.position = new Vector3(0, 1.6f, -90 + i * 7);
            //}
        }

        //GameObject player = GameObject.Find("Player");
        //player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {




    }
}