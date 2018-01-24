using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LevelObjectiveType {

    DropBalls
};

public enum GameState {

    Normal,
    BallDropped,
    LastButOneBallDropped,
    LastBallDropped
};

public enum BallType
{
    Normal_10_Points
};

public class SceneController : MonoBehaviour {

    public int numberOfBallsToDrop;
    public LevelObjectiveType objectiveType;
    public Text scoreText;
    public AmmoSpawnerScript ammoSpawnerScript;
    public string strLevelNumber;
    public GameObject normal_10_PointsTextObj;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup CountdownAfterLastAmmoFireCanvasGroup;
    public AudioSource GameOverAudioSource;

    private float timePassedSinceLastAmmoFire;
    private bool lastAmmoHasBeenFired;
    private int levelScore;
    private GameState _gameState;
    private int deltaScoreToBeAddedOnPartObjectiveCompletion;
    private bool gameConcluded; //Game won/lost or still in progress

    //Objective type - Drop Balls
    private int ballsDroppedSoFar;

	// Use this for initialization
	void Start () {
		
        this.levelScore = 0;
        this._gameState = GameState.Normal;
        this.timePassedSinceLastAmmoFire = 10.0f;
        this.lastAmmoHasBeenFired = false;
        this.gameConcluded = false;

        scoreText.text = "Level: " + strLevelNumber + ", Score: " + levelScore + ", Ammo: " + (ammoSpawnerScript.ammoLeft());

        if (objectiveType == LevelObjectiveType.DropBalls) {

            deltaScoreToBeAddedOnPartObjectiveCompletion = 10;
            ballsDroppedSoFar = 0;
        }
	}

    void Update()
    {
        if ((GameManager.instance.gameIsPaused() == false) && (this.gameConcluded == false))
        {
            int timeInt = (int)Time.time;
            if ((Time.time - (float)timeInt >= 0.0f) && (Time.time - (float)timeInt <= 0.4f))
                scoreText.text = "Level: " + strLevelNumber + ", Score: " + levelScore + ", Ammo: " + (ammoSpawnerScript.ammoLeft());

            if ((this.lastAmmoHasBeenFired) && (this.timePassedSinceLastAmmoFire > 0.0f))
            {
                this.timePassedSinceLastAmmoFire -= Time.deltaTime;
                CountdownAfterLastAmmoFireCanvasGroup.GetComponentInChildren<Text>().text = this.timePassedSinceLastAmmoFire.ToString("N2");
            }

            if ((this.timePassedSinceLastAmmoFire <= 0.0f) && (this.GameOverCanvasGroup.alpha == 0f))
            {
                this.timePassedSinceLastAmmoFire = 0.0f;
                CountdownAfterLastAmmoFireCanvasGroup.GetComponentInChildren<Text>().text = "0";

                CountdownAfterLastAmmoFireCanvasGroup.alpha = 0f;
                CountdownAfterLastAmmoFireCanvasGroup.interactable = false;
                CountdownAfterLastAmmoFireCanvasGroup.blocksRaycasts = false;

                //If the ojective has not been met, then show the game over dialog
                if (ObjectiveHasbeenMet())
                {
                    //Show victory dialog
                }
                else
                {
                    //Show game over dialog
                    this.GameOverCanvasGroup.alpha = 1f;
                    this.GameOverCanvasGroup.interactable = true;
                    this.GameOverCanvasGroup.blocksRaycasts = true;

                    this.GameOverAudioSource.Play();
                    this.gameConcluded = true;
                }
            }
        }
    }

    private bool ObjectiveHasbeenMet()
    {
        if (this.objectiveType == LevelObjectiveType.DropBalls)
        {
            if (ballsDroppedSoFar == numberOfBallsToDrop)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public GameState ballDropped(BallType droppedBallType)
    {
        if (this.gameConcluded == false)
        {
            this.levelScore += deltaScoreToBeAddedOnPartObjectiveCompletion;
            ballsDroppedSoFar += 1;

            //Play the score animation
            if (droppedBallType == BallType.Normal_10_Points)
            {
                GameObject instanceOfNormal_10_PointsTextObj = GameObject.Instantiate(this.normal_10_PointsTextObj);
                GameObject.Destroy(instanceOfNormal_10_PointsTextObj, 1);
            }

            if (ballsDroppedSoFar >= numberOfBallsToDrop)
            {

                _gameState = GameState.LastBallDropped;
                this.gameConcluded = true;

                //Victory
                StartCoroutine(showLevelVictoryScene());
            }
            else if (ballsDroppedSoFar == (numberOfBallsToDrop - 1))
            {

                _gameState = GameState.LastButOneBallDropped;

            }
            else if (ballsDroppedSoFar > 0)
            {

                _gameState = GameState.BallDropped;
            }
        }

        return _gameState;
    }

    public void cubeFired()
    {
        if (ammoSpawnerScript.ammoLeft() == 0)
        {
            this.lastAmmoHasBeenFired = true;

            CountdownAfterLastAmmoFireCanvasGroup.alpha = 1f;
            CountdownAfterLastAmmoFireCanvasGroup.interactable = true;
            CountdownAfterLastAmmoFireCanvasGroup.blocksRaycasts = true;
        }

    }

    public int getCurrentScore()
    {
        return this.levelScore;
    }

    IEnumerator showLevelVictoryScene()
    {
        float fadeTime = GameManager.instance.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        GameManager.instance.LoadLevelVictoryScene();
    }

}
