using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private bool _gameIsPaused = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //levelsManagerScript = GetComponent<LevelsManager>();

        //_currentPlatform = CurrentPlatform.Android;

        //InitGame (); //This is now called from the main UI
    }

    void OnGUI()
    {
        if (_gameIsPaused)
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
    }

    void OnApplicationFocus(bool hasFocus)
    {
        _gameIsPaused = !hasFocus;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        _gameIsPaused = pauseStatus;
    }

    public void pauseGame()
    {
        _gameIsPaused = true;
    }

    public void resumeGame()
    {
        _gameIsPaused = false;
    }

    public bool gameIsPaused()
    {
        return _gameIsPaused;
    }

    public void LoadModule1_LevelsScreen()
    {
        SceneManager.LoadSceneAsync("Module1_Menu");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadSceneWithName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    /*public void InitGame()
    {

        levelsManagerScript.LoadLevel(level, checkpointReached);
    }*/
}