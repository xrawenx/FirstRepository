using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI cherryText;
    public TextMeshProUGUI gemText;
    
    int cherry = 1;
    int gem = 2;
    
    
    private void Awake() {
        instance = this;
    }

    public void Start () {
        cherry = 0;
        cherryText.text = ": " + cherry; 
        gem = 0;
        gemText.text = ": " + gem;
    }

    public void AddPoint() {
        cherry += 1;
        cherryText.text = ": " + cherry;
        gem += 2;
        gemText.text = ": " + gem;
    }
    
    

   

    
}
