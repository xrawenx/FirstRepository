using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
      if(instance == null) 
        {
            instance = this;
        }   
    }

    public void ChangeScore(int cherryValue) 
    { 
     score += cherryValue;
     text.text = "X" + score.ToString();
    }

    
}