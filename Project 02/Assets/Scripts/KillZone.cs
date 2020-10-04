using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth
            = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.health = playerHealth.health - 15;
        }
    }
}
