using UnityEngine;

public class Explosion : MonoBehaviour 
{
	void OnAnimationFinish ()
	{
		Debug.Log ("爆発終わり");
		Destroy (gameObject);
	}
}
