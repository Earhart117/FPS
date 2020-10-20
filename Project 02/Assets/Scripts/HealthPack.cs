using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour

{
    public AudioSource _healthPack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Picked up health pack");
            _healthPack.Play();
            other.GetComponent<PlayerHealth>().HealthPack(75);
            Destroy(this.gameObject);
        }
    }
}
