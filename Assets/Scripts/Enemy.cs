﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	// コンポーネント
	Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () 
	{

		Debug.Log ("Start");
		spaceship = GetComponent<Spaceship> ();

		spaceship.Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}

		while(true) {
			// 子要素取得
			for(int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild(i);

				spaceship.Shot(shotPosition);
			}

			yield return new WaitForSeconds (spaceship.shotDelay);
		}

	}
}
