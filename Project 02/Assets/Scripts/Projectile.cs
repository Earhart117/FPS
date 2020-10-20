using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{

    public float speed;
    PlayerHealth playerHealth;
    public int bulletDamage;
    public AudioSource _hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hit");
            _hitPlayer.Play();
            other.GetComponent<PlayerHealth>().DamagePlayer(bulletDamage);
            Destroy(this.gameObject);
        }
    }
}
