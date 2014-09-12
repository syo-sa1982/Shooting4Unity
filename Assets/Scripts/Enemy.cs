using UnityEngine;
using System.Collections;

public class Enemy : Spaceship 
{
	// Use this for initialization
	IEnumerator Start () 
	{

		Debug.Log ("Start");

		this.Move (transform.up * -1);

		if (this.canShot == false) { yield break; }

		while(true) {
			// 子要素取得
			for(int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild(i);

				this.Shot(shotPosition);
			}

			yield return new WaitForSeconds (this.shotDelay);
		}

	}

	protected override void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名取得
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		// レイヤー名がBulletPlayerの時以外はリターン
		if (layerName != "BulletPlayer") { return; }

		// 弾削除
		Destroy (c.gameObject);

		// 爆発
		this.Explosion ();

		// エネミーの削除
		Destroy (gameObject);
	}
}
