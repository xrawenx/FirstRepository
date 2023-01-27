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
	public Toggle[] fullscreenToggle;
	public int[] screenWidths;
	int activeScreenResIndex;

	void Start() {

	}

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
	   if (resolutionToggles [i].isOn) {
		   activeScreenResIndex = i;
		   float aspectRatio = 16 / 9f;
		   Screen.SetResolution(screenWidths [i], (int)(screenWidths [i] / aspectRatio), false);
		   PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
	   }
   }

   public void SetFullscreen(bool isFullscreen) {
		for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].interactable = !isFullscreen;
		}

		if (isFullscreen) {
			Resolution[] allResolutions = Screen.resolutions;
			Resolution maxResolution = allResolutions [allResolutions.Length - 1];
			Screen.SetResolution (maxResolution.width, maxResolution.height, true);
		} else {
			SetScreenResolution (activeScreenResIndex);
		}
   }

   public void SetMasterVolume(float value)
   {
	   AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
   }

   public void SetMusicVolume(float value)
   {
	   AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
   }

   public void SetSfxVolume(float value)
   {
	   AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
   }


}