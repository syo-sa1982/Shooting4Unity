using UnityEngine;

// Rigidbody2D必須属性
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Spaceship : MonoBehaviour 
{
	// 移動速度
	public float speed;

	// 発射レート
	public float shotDelay;

	// 弾のPrefab
	public GameObject bullet;

	// 発砲するかどうか
	public bool canShot;

	public GameObject explosion;

	private Animator animator;


	// 爆発
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	// 弾の作成
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}


	public void SetAnimator()
	{
		animator = GetComponent<Animator> ();
	}

	public Animator GetAnimator()
	{
		return animator;
	}

	// 機体の移動
	protected abstract void Move (Vector2 direction);
}
