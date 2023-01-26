using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public void OnClick_back()
    {
        MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
}
