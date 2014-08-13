using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	// 移動速度
	public float speed = 5;
	// PlayerBullet
	public GameObject bullet;

	// Startメソッドをコルーチンとして呼び出し
	IEnumerator Start() 
	{
		while(true) {
			// 作成したいオブジェクト、位置、角度
			Instantiate (bullet, transform.position, transform.rotation);
			// 待つ
			yield return new WaitForSeconds (0.05f);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		// 右左
		float x = Input.GetAxisRaw ("Horizontal");
		// 上下
		float y = Input.GetAxisRaw ("Vertical");

		// 移動方向決定
		Vector2 direction = new Vector2 (x, y).normalized;

		// 移動する向きとスピード
		rigidbody2D.velocity = direction * speed;
	}
}
