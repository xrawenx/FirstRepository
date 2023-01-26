using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void GoToScene(string sceneName) {
	   SceneManager.LoadScene(sceneName);
   }
   public void QuitApp() {
	   Application.Quit();
	   Debug.Log("Application has quit.");
   }

   public void OnClick_Controls()
   {
	   MenuManager.OpenMenu(Menu.CONTROLS, gameObject);
   }

   public void OnClick_Volume()
   {
	   MenuManager.OpenMenu(Menu.VOLUME, gameObject);
   }


}
