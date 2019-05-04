using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBoss : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public Slider healthbar;
    public Text mytext;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 15f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
        mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            DealDamage(5);
            Debug.Log("Button Pushed");
        }      

        if(CurrentHealth <= 0)
        {
            mytext.text = "Dead";
            CurrentHealth = 0;
        }
    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthbar.value = CalculateHealth();
        mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
