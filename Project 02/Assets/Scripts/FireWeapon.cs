using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeedbackObject;
    [SerializeField] int weaponDamage = 20;
    [SerializeField] LayerMask hitLayers;

    RaycastHit objectHit; // stores raycast hit info


    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.Mouse0))
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
        if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers))
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
                }
            }
            
           
            
            

            //check health, kill enemy
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
