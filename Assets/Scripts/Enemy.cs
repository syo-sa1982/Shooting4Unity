using UnityEngine;
using System.Collections;

public class Enemy : Spaceship 
{
	// ヒットポイント
	public int hp = 1;

	// Use this for initialization
	IEnumerator Start () 
	{
		this.SetAnimator ();

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
		rigidbody2D.velocity = direction * this.speed;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名取得
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		// レイヤー名がBulletPlayerの時以外はリターン
		if (layerName != "BulletPlayer") { return; }

		// PlayerBulletのTransformを取得
		Transform playerBulletTransform = c.transform.parent;

		// Bulletコンポーネントを取得
		Bullet bullet =  playerBulletTransform.GetComponent<Bullet>();

		// ヒットポイントを減らす
		hp = hp - bullet.power;

		// 弾削除
		Destroy (c.gameObject);

		// ヒットポイントが0以下であれば
		if (hp <= 0) {
			// 爆発
			this.Explosion ();

			// エネミーの削除
			Destroy(gameObject);
		} else {
			this.GetAnimator().SetTrigger("Damage");
		}
	}
}
