using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float Timer { get; set; }
    public float Currenttime { get; set; }
    public Slider timebar;
    public Text mytext;


    // Start is called before the first frame update
    void Start()
    {
        Timer = 60f;
        Currenttime = Timer;
        timebar.value = CalculateTime();
    }

    // Update is called once per frame
    void Update()
    {
        TimeDrop(Time.deltaTime);

        if (Currenttime <= 0.0f)
        {
            Timer = 0.0f;
            mytext.text = "0.0";
        }
    }

    void TimeDrop(float time)
    {
        Currenttime -= time;
        mytext.text = Currenttime.ToString();
        timebar.value = CalculateTime();
    }

    float CalculateTime()
    {
        return Currenttime / Timer;
    }
}
