using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBoss : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public static int damaged;
    public static bool unblockable = false;
    float deadTime = 3.0f;
    public int damageUpdate;
    public Slider healthbar;
    public Text mytext;

    public GameObject youDead;

    // Start is called before the first frame update
    void Start()
    {
        damaged = 0;
        damageUpdate = 0;
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
        mytext.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged != damageUpdate)
        {
            if (!playerCollider.blocking || unblockable)
            {
                unblockable = false;
                damageUpdate = damaged;
                DealDamage(5);
                Debug.Log("Button Pushed");
            }
        }      

        if(CurrentHealth <= 0)
        {
            mytext.text = "Dead";
            youDead.SetActive(true);
            CurrentHealth = 0;
            if(deadTime > 0.0f)
            {
                deadTime -= Time.deltaTime;

            }
            else
            {
                SceneManager.LoadScene("Scene1");
            }
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
