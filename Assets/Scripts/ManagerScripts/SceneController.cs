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

public class SceneController : MonoBehaviour {

    public int numberOfBallsToDrop;
    public LevelObjectiveType objectiveType;
    public Text scoreText;
    public AmmoSpawnerScript ammoSpawnerScript;
    public string strLevelNumber;

    private int levelScore;
    private GameState _gameState;
    private int deltaScoreToBeAddedOnPartObjectiveCompletion;

    //Objective type - Drop Balls
    private int ballsDroppedSoFar;

	// Use this for initialization
	void Start () {
		
        this.levelScore = 0;
        this._gameState = GameState.Normal;

        scoreText.text = "Level: " + strLevelNumber + ", Score: " + levelScore + ", Ammo: " + (ammoSpawnerScript.ammoLeft());

        if (objectiveType == LevelObjectiveType.DropBalls) {

            deltaScoreToBeAddedOnPartObjectiveCompletion = 10;
            ballsDroppedSoFar = 0;
        }
	}

    void Update()
    {
        int timeInt = (int)Time.time;
        if ((Time.time - (float)timeInt >= 0.0f) && (Time.time - (float)timeInt <= 0.4f))
            scoreText.text = "Level: " + strLevelNumber + ", Score: " + levelScore + ", Ammo: " + (ammoSpawnerScript.ammoLeft());
    }

    public GameState ballDropped()
    {
        this.levelScore += deltaScoreToBeAddedOnPartObjectiveCompletion;
        ballsDroppedSoFar += 1;

        if (ballsDroppedSoFar >= numberOfBallsToDrop) {

            _gameState = GameState.LastBallDropped;

        } else if (ballsDroppedSoFar == (numberOfBallsToDrop - 1)) {

            _gameState = GameState.LastButOneBallDropped;

        } else if (ballsDroppedSoFar > 0) {

            _gameState = GameState.BallDropped;
        }

        return _gameState;
    }

    public void ammoFired()
    {
        scoreText.text = "Level: " + strLevelNumber + ", Score: " + levelScore + ", Ammo: " + (ammoSpawnerScript.ammoLeft());
    }

    public int getCurrentScore()
    {
        return this.levelScore;
    }
}
