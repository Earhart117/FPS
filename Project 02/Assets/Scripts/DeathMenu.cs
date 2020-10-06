using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    
    Level01Controller _currentScore;
    public static bool playerIsDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (playerIsDead)
            {
                Cursor.lockState = CursorLockMode.Locked;
                //Resume();
            }
            else
            {
                
            }
    }
    
}
