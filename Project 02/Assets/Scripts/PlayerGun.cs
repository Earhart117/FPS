using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public ParticleSystem playerGun;
    
    public AudioSource _gunShot;
    PlayerHealth health;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pHealth = PlayerHealth.health;
        if (PlayerHealth.health == 0)
        {
            isDead = true;
            Debug.Log("player is dead");
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0)&& pHealth >0 && PauseMenu.gameIsPaused == false)
            {
            playerGun.Emit(10);
            _gunShot.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
        }

    }
    public void PlayShot(AudioClip clip)
    {
        _gunShot.clip = clip;
        _gunShot.Play();
    }
}
