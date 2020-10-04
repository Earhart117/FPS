using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    

    public Slider healthSlider;
    public PlayerHealth playerHealth;


    //TO DO: Add dead screen



    private void Start()
    {

    }


    public void UpdateHealthSlider()
    {
        //set slider value = to health
        healthSlider.value = playerHealth.health;
    }

    public void ActivateDeathScreen()
    {
        
    }
}
