﻿using UnityEngine;

public class Score : MonoBehaviour 
{
	// スコアを表示するGUIText
	public GUIText scoreGUIText;

	// ハイスコアを表示するGUIText
	public GUIText highScoreGUIText;

	// スコア
	private int score;

	// ハイスコア
	private int highScore;

	// PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () 
	{
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// スコアがハイスコアより大きければ
		if (highScore < score) {
			highScore = score;
		}

		// スコア・ハイスコアを表示する
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}

	// ゲームリセット
	private void Initialize()
	{
		// スコアを0に戻す
		score = 0;

		// ハイスコアを取得する。保存されてなければ0を取得する。
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	public void AddPoint(int point)
	{
		score = score + point;
	}

	public void Save()
	{
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

		Initialize ();
	}
}
