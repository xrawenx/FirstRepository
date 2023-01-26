using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
   public void OnClick_back()
    {
        MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}
