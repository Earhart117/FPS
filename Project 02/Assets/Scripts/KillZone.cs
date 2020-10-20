using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] GameObject _player;
    /// PlayerHealth playerHealth;
    int damage = 1;
    bool isIn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

           
            Debug.Log("is in");

        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
            Debug.Log("being damaged");
        }
       

    }
}
