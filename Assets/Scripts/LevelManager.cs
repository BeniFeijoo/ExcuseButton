using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;

    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("GameScene", sceneLoadDelay));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
