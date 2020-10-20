using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 60f;
    [SerializeField] GameObject visualFeedbackObject;
    [SerializeField] int weaponDamage = 20;
    [SerializeField] LayerMask hitLayers;

    public AudioSource _enemyHit;
    public AudioSource _hitWall;
    PauseMenu pauseMenu;

    RaycastHit objectHit; // stores raycast hit info

    int pHealth = PlayerHealth.health;
    void Update()
    {
        int pHealth = PlayerHealth.health;
        if  (Input.GetKeyDown(KeyCode.Mouse0) && pHealth > 0 && PauseMenu.gameIsPaused == false)
        {
            Shoot();
        }
    }

    //Shoot gun using raycast
    void Shoot()
    {
        //calc direction to shoot
        Vector3 rayDirection = cameraController.transform.forward;
        //cast debug ray
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.blue, 1f);
        //do raycast
        if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers) && (PlayerHealth.health > 0))
        {
            
            Debug.Log("You Hit the  " + objectHit.transform.name);

            if (objectHit.transform.tag == "Enemy")
            {
                Debug.Log("deal damage");
                //visual feedback
                visualFeedbackObject.transform.position = objectHit.point;
                //apply damage if enemy
                EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
                if (enemyShooter != null)
                {
                    enemyShooter.TakeDamage(weaponDamage);
                    _enemyHit.Play();
                    Debug.Log("Hit enemy");
                }
            }
            if (objectHit.transform.tag == "Wall")
                {
                    _hitWall.Play();
                Debug.Log("Hit wall");
                }





            //check health, kill enemy
        }
        else
        {
            Debug.Log("Miss");
        }
    }
    public void PlayHit(AudioClip clip)
    {
        _enemyHit.clip = clip;
        _enemyHit.Play();
    }
}
