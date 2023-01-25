using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private ScoreManager ScoreManager;
    public int cherryValue = 1;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
           
            Destroy (gameObject);

            
            ScoreManager.instance.AddPoint();
            
        }


    }

 
}
