using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour 
{
	// Waveプレハブを格納する
	public GameObject[] waves;

	// 現在のWave
	private int currentWave;

	// Use this for initialization
	IEnumerator Start () 
	{
		// Waveが存在しなければコルーチンを終了する
		if (waves.Length == 0) { yield break; }

		while (true) {
			// Wave作成
			GameObject wave =(GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
		}

	}
}
