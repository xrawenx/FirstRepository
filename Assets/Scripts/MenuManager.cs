using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu, controlsMenu, volumeMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("mainMenu").gameObject;
        controlsMenu = canvas.transform.Find("controlsMenu").gameObject;
        volumeMenu = canvas.transform.Find("volumeMenu").gameObject;

        IsInitialised = true;

    }

    public static void OpenMenu(Menu menu, GameObject callingMenu) 
    {
        if(!IsInitialised)
        Init();

        switch (menu)
        {
            case Menu.MAIN_MENU:
            mainMenu.SetActive(true);
            break;
            case Menu.CONTROLS:
            controlsMenu.SetActive(true);
            break;
            case Menu.VOLUME:
            volumeMenu.SetActive(true);
            break;
        }

        callingMenu.SetActive(false);
    }
}
