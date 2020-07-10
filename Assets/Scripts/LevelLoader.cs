using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitTime = 3;
    int currentSceneIndex;


    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {

            StartCoroutine(StartScene());
          
        }
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneLoad();

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu");
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);       
    }

    public void SplashScreen()
    {
        SceneManager.LoadScene("Splash Screen");

    }

    public void LoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }

   public void OptionMenu()
    {
        SceneManager.LoadScene("Option");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
