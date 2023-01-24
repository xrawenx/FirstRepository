using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    ScoreManager.instance.AddPoint (cherry, gem;)
    public TextMeshProUGUI cherryText;
    public TextMeshProUGUI gemText;

    int cherry = 0;
    int gem = 0;

    public void AddPoint(int cherryValue)
    {
        cherry = cherry + cherryValue;
        cherryText.text = cherry.ToString();
    
    }

    public void AddPoints(int gemValue)
    {
        gem = gem + gemValue;
        gemText.text = gem.ToString();
    }

    
}
