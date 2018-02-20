using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private bool _gameIsPaused = false;
    public string currentLevelSceneName;

    private int maxNumberOflevelsForModule1 = 20;
    private int maxNumberOflevelsForModule2 = 20;
    private int maxNumberOflevelsForModule3 = 20;

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
        this.currentLevelSceneName = sceneName;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadNextLevel()
    {
        char[] separatingChars = {'_'};
        string[] splitLevelNameParts = this.currentLevelSceneName.Split(separatingChars);
        int currentLevelNum = 0;
        int.TryParse(splitLevelNameParts[1], out currentLevelNum);
        int currentModuleNum = 1;

        if (splitLevelNameParts[0].EndsWith("1"))
        {
            currentModuleNum = 1;
        }
        else if (splitLevelNameParts[0].EndsWith("2"))
        {
            currentModuleNum = 2;
        }
        else if (splitLevelNameParts[0].EndsWith("3"))
        {
            currentModuleNum = 3;
        }

        //Switch modules if all the levels in the module have been won
        if ((currentModuleNum == 1) && (currentLevelNum >= maxNumberOflevelsForModule1))
        {
            currentLevelSceneName = "Scene2_1";
            SceneManager.LoadSceneAsync("Scene2_1");
        }
        else if ((currentModuleNum == 2) && (currentLevelNum >= maxNumberOflevelsForModule2))
        {
            currentLevelSceneName = "Scene3_1";
            SceneManager.LoadSceneAsync("Scene3_1");
        }
        else if ((currentModuleNum == 3) && (currentLevelNum >= maxNumberOflevelsForModule3))
        {
            SceneManager.LoadSceneAsync("EntireGameVictoryScene");
        }
        else
        {
            currentLevelSceneName = "Scene" + currentModuleNum + "_" + (currentLevelNum + 1);
            SceneManager.LoadSceneAsync("Scene" + currentModuleNum + "_" + (currentLevelNum + 1));
        }
    }

    public bool checkIfNextLevelIsAvailable()
    {
        char[] separatingChars = { '_' };
        string[] splitLevelNameParts = this.currentLevelSceneName.Split(separatingChars);
        int currentLevelNum = 0;
        int.TryParse(splitLevelNameParts[1], out currentLevelNum);
        int currentModuleNum = 1;

        if (splitLevelNameParts[0].EndsWith("1"))
        {
            currentModuleNum = 1;
        }
        else if (splitLevelNameParts[0].EndsWith("2"))
        {
            currentModuleNum = 2;
        }
        else if (splitLevelNameParts[0].EndsWith("3"))
        {
            currentModuleNum = 3;
        }

        if ((currentModuleNum == 1) && (currentLevelNum >= maxNumberOflevelsForModule1))
        {
            return false;
        }
        else if ((currentModuleNum == 2) && (currentLevelNum >= maxNumberOflevelsForModule2))
        {
            return false;
        }
        else if ((currentModuleNum == 3) && (currentLevelNum >= maxNumberOflevelsForModule3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void LoadLevelVictoryScene()
    {
        SceneManager.LoadSceneAsync("LevelVictoryScene");
    }

    /*public void InitGame()
    {

        levelsManagerScript.LoadLevel(level, checkpointReached);
    }*/
}