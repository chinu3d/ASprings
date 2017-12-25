﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReceiverScript : MonoBehaviour {

    public SceneController sceneController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("DropBall"))
        {
            GameState currentGameState = sceneController.ballDropped();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("DropBall"))
        {
            GameState currentGameState = sceneController.ballDropped();
        }
    }
}