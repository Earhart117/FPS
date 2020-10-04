using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DamagePlayer(12);
        }
    }
    public void DamagePlayer(int _damageAmount)
     {

        //subtract health6
        health -= _damageAmount;
        if(health<0)
        {
            health = 0;
            
        }
        //update slider
        uiManager.UpdateHealthSlider();
    }
    
}
