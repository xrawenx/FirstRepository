using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public GameObject mainMenuHolder;
	public GameObject controlsMenuHolder;
	public GameObject volumeMenuHolder;
	public GameObject settingsMenuHolder;

	public Slider[] volumeSliders;
	public Toggle[] resolutionToggles;
	public int[] screenWidths;

   public void Play() {
	   SceneManager.LoadScene("1-1");
   }
   public void QuitApp() {
	   Application.Quit();
	   Debug.Log("Application has quit.");
   }

   public void ControlsMenu()
   {
	   mainMenuHolder.SetActive (false);
	   controlsMenuHolder.SetActive (true);
   }

   public void SettingsMenu()
   {
	   mainMenuHolder.SetActive (false);
	   settingsMenuHolder.SetActive (true);
   }

   public void VolumeMenu()
   {
	   mainMenuHolder.SetActive (false);
	   volumeMenuHolder.SetActive (true);
   }

   public void MainMenu()
   {
	   mainMenuHolder.SetActive (true);
	   controlsMenuHolder.SetActive (false);
   }

   public void SetScreenResolution(int i)
   {

   }

   public void SetFullscreen(bool isFullscreen)
   {

   }

   public void SetMasterVolume(float value)
   {

   }

   public void SetMusicVolume(float value)
   {

   }

   public void SetSfxVolume(float value)
   {

   }


}