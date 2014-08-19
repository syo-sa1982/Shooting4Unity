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
			// 待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
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
		spaceship.Move (direction);
	}
}
