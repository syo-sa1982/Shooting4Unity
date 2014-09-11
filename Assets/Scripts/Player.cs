using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	// コンポーネント呼び出し
	Spaceship spaceship;

	// Startメソッドをコルーチンとして呼び出し
	IEnumerator Start() 
	{
		// コンポーネント取得
		spaceship = GetComponent<Spaceship> ();

		while(true) {
			// 作成したいオブジェクト、位置、角度
			spaceship.Shot (transform);

			// ショット音を鳴らす
			audio.Play();

			// 待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		// 左右
		float x = Input.GetAxisRaw ("Horizontal");
		// 上下
		float y = Input.GetAxisRaw ("Vertical");

		// 移動方向決定
		Vector2 direction = new Vector2 (x, y).normalized;

		// 移動する向きとスピード
		spaceship.Move (direction);

		// 移動の制限
		Clamp ();
	}

	// 移動制限
	void Clamp()
	{
		// 左下のワールド座標
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));

		// 右下のワールド座標
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));

		// プレイヤーの座標を取得
		Vector2 pos = transform.position;

		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;

	}

	// 衝突処理
	void OnTriggerEnter2D (Collider2D c) 
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		// レイヤー名がBullet(Enemy)の時は弾を消す
		if(layerName == "BulletEnemy") 
		{
			// 弾の削除
			Destroy (c.gameObject);
		}

		// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
		if (layerName == "BulletEnemy" || layerName == "Enemy") {
			// 爆発
			spaceship.Explosion ();

			// プレイヤー削除
			Destroy (gameObject);
		}
	}
}
