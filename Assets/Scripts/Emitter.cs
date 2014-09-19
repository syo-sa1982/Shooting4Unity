﻿using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour 
{
	// Waveプレハブを格納する
	public GameObject[] waves;

	// 現在のWave
	private int currentWave;

	// Managerコンポーネント
	private Manager manager;

	// Use this for initialization
	IEnumerator Start () 
	{
		Debug.Log ("Emitter Start");
		// Waveが存在しなければコルーチンを終了する
		if (waves.Length == 0) { yield break; }

		// Managerコンポーネントをシーン内から探して取得する
		manager = FindObjectOfType<Manager>();

		while (true) {

			// タイトル表示中は待機
			while(manager.IsPlaying() == false) {
				yield return new WaitForEndOfFrame ();
			}

			// Wave作成
			GameObject wave =(GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

			// Waveの親にEmitterを追加
			wave.transform.parent = transform;

			// Waveの子要素のEnemyが全て削除されるまで待機する
			while (wave.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			// Waveの削除
			Destroy (wave);

			// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
			if (waves.Length <= ++currentWave) {
				currentWave = 0;
			}
		}

	}
}
