using UnityEngine;

public class Background : MonoBehaviour 
{
	// スクロールスピード
	public float speed = 0.1f;

	// Update is called once per frame
	void Update () 
	{
		// Y軸を時間経過で0から１に変化させる
		float y = Mathf.Repeat (Time.time * speed, 1);

		// Y軸をずらすオフセット作成
		Vector2 offset = new Vector2 (0, y);

		// マテリアルにオフセットを設定
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
