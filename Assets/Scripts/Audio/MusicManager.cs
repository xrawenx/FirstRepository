using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip mainTheme;
	public AudioClip menuTheme;

	string sceneName;

	void Start() {
		
        SceneManager.sceneLoaded += this.OnLoadCallback;
    }


    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
		string newSceneName = SceneManager.GetActiveScene ().name;
		if (newSceneName != sceneName) {
			sceneName = newSceneName;
			Invoke ("PlayMusic", .2f);
		}
	}

	void PlayMusic() {
		AudioClip clipToPlay = null;

		if (sceneName == "Menu") {
			clipToPlay = menuTheme;
		} else if (sceneName == "1-1") {
			clipToPlay = mainTheme;
		}

		if (clipToPlay != null) {
			AudioManager.instance.PlayMusic (clipToPlay, 2);
			Invoke ("PlayMusic", clipToPlay.length);
		}

	}

}