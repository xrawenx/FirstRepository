using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_CherryCounter : MonoBehaviour
{
    Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of cherry to display
        if (counterText.text != SC_2DCherry.totalCherry.ToString())
        {
            counterText.text = SC_2DCherry.totalCherry.ToString();
        }
    }
}
