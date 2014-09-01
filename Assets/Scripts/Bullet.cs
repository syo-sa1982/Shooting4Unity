using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public int speed = 10;

	// ゲームオブジェクト生成から削除まで
	public float lifeTime = 5;

	// Use this for initialization
	void Start () 
	{
		// Y方向に移動
		rigidbody2D.velocity = transform.up.normalized * speed;

		// 弾の寿命が切れたら削除
		Destroy (gameObject, lifeTime);
	}
}
