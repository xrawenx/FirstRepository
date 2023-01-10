using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_2DCherry : MonoBehaviour
{
    //Keep track of total picked cherry (Since the value is static, it can be accessed at "SC_2DCherry.totalCherry" from any script)
    public static int totalCherry = 0;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the cherry if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add cherry to counter
            totalCherry++;
            //Test: Print total number of cherry
            Debug.Log("You currently have " + SC_2DCherry.totalCherry + " Cherry.");
            //Destroy cherry
            Destroy(gameObject);
        }
    }
}
