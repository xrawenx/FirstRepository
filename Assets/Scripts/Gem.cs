using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private ScoreManager ScoreManager;
    public int gemValue = 2;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
           
            Destroy (gameObject);

            
            ScoreManager.instance.AddPoint();
            
        }


    }

 
}
