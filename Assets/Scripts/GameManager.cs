using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
   
    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int cherry { get; private set; }

    public Image fadePlane;
    public GameObject gameOverUI;
    

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;

        NewGame();
        FindObjectOfType<PlayerLife> ().OnDeath += GameOver;
        gameOverUI.SetActive (false);
        
    }

    public void NewGame()
    {
        lives = 3;
        cherry = 0;

        LoadLevel(1, 1);
    }

    public void GameOver()
    {
      AudioManager.instance.PlaySound2D ("GameOver");
      StartCoroutine(Fade (Color.clear, Color.black,1));
        gameOverUI.SetActive (true);
        
      NewGame();
    }

    IEnumerator Fade(Color from, Color to, float time) {
        float speed = 1 / time;
        float percent = 0;

        while (percent < 1) {
            percent += Time.deltaTime * speed;
            fadePlane.color = Color.Lerp(from,to,percent);
            yield return null;
        }
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        LoadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            LoadLevel(world, stage);
        } else {
            GameOver();
        }
    }

    public void AddCherry()
    {
        cherry++;

        if (cherry == 100)
        {
            cherry = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }

    // UI Input
    public void StartNewGame() {
		SceneManager.LoadScene ("1-1");
	}

	public void ReturnToMainMenu() {
		SceneManager.LoadScene ("Menu");
	}

}
