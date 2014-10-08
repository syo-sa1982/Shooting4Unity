using UnityEngine;

public class Manager : MonoBehaviour 
{
	public GameObject player;

	private GameObject title;

	void Awake ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Manager Start");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// ゲーム中ではなく、Xキーが押されたらtrueを返す。
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) {
			GameStart ();
		}
	}

	void GameStart () 
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}

	public void GameOver () 
	{
		// ハイスコアの保存
		FindObjectOfType<Score> ().Save ();

		// ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}


	public bool IsPlaying()
	{
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}
}
