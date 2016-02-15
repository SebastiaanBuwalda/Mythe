﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratingScript : MonoBehaviour {
	//The first list contains objects that will spawn from the start. The second one contains objects that will be spawned after the player has achieved a certain score.
	[SerializeField]
	private List<GameObject> gameObjectList = new List<GameObject> ();
	[SerializeField]
	private List<GameObject> extraObjectList = new List<GameObject> ();

	[SerializeField]
	private List<int> unlockValues = new List<int>();

	[SerializeField]
	private float minTimeInBetweenSpawns;
	[SerializeField]
	private float maxTimeInBetweenSpawns;

	[SerializeField]
	private int minXPosition;
	[SerializeField]
	private int maxXPosition;

	//This is only for testing, will be removed later.
	private int testScore;

	private Vector2 spawnPosition;


	void Start()
	{
		//Start spawning objects!
		StartCoroutine (SpawnCounter());
	}

	void SpawnNextObject()
	{
		//Possibly add new enemies.
		AddNewObjects ();
		testScore++;
		int whatToSpawn = Random.Range (0, gameObjectList.Count);
		float xPosition = Random.Range (minXPosition, maxXPosition);
		spawnPosition = new Vector2 (xPosition, 0);

		//This is where the object actually spawns.
		Instantiate (gameObjectList [whatToSpawn],spawnPosition,Quaternion.identity);

		StartCoroutine (SpawnCounter());
	}

	IEnumerator SpawnCounter()
	{
		//Wait a random (but controlled) time in between spawns...
		yield return new WaitForSeconds (Random.Range (minTimeInBetweenSpawns, maxTimeInBetweenSpawns));
		//Since the IENumerator and function call on each other objects will spawn in intervals.
		SpawnNextObject ();
	}

	void AddNewObjects()
	{
		//This function adds new objects to the pool of objects that can spawn if the player has enough score.
		for(int i = 0; i<unlockValues.Count; i++) 
			{
			if (testScore >= unlockValues[i]) 
				{
					unlockValues.Remove (unlockValues[i]);
					gameObjectList.Add (extraObjectList [i]); 
					extraObjectList.Remove (extraObjectList [i]);
				}
			}
	}
}
