using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GroundScript : MonoBehaviour
{
	//Player player;
	////PlayerShoot player;
	//public Texture2D baseTexture;
	//Texture2D cloneTexture;
	//SpriteRenderer sr;
	//[SerializeField] float drillTime = 0.3f;

	//float widthWorld, heightWorld;
	//int widthPixel, heightPixel;

	//public float WidthWorld
	//{
	//	get
	//	{
	//		if (widthWorld == 0)
	//			widthWorld = sr.bounds.size.x;
	//		return widthWorld;
	//	}

	//}
	//public float HeightWorld
	//{
	//	get
	//	{
	//		if (heightWorld == 0)
	//			heightWorld = sr.bounds.size.y;
	//		return heightWorld;
	//	}

	//}
	//public int WidthPixel {
	//	get
	//	{
	//		if (widthPixel == 0)
	//			widthPixel = sr.sprite.texture.width;

	//		return widthPixel;
	//	}
	//}
	//public int HeightPixel
	//{
	//	get
	//	{
	//		if (heightPixel == 0)
	//			heightPixel = sr.sprite.texture.height;

	//		return heightPixel;
	//	}
	//}


	//// Use this for initialization
	//void Start ()
	//{
	//	player = FindObjectOfType<Player>();
	//	//player = FindObjectOfType<PlayerShoot>();
	//	sr = GetComponent<SpriteRenderer>();
	//	cloneTexture = Instantiate(baseTexture);
	//	cloneTexture.alphaIsTransparency = true;

	//	if (cloneTexture.format != TextureFormat.ARGB32)
	//		Debug.LogWarning("Texture must be ARGB32");
	//	if (cloneTexture.wrapMode != TextureWrapMode.Clamp)
	//		Debug.LogWarning("wrapMode must be Clamp");

	//	UpdateTexture();
	//	gameObject.AddComponent<PolygonCollider2D>();

	//}

	//void Drill(Collider2D col)
	//{
	//   // print(string.Format("{0},{1},{2},{3}", WidthPixel, HeightPixel, WidthWorld, heightWorld));
	//   //TODO optimize This

	//	Vector2Int c = World2Pixel(col.bounds.center);
	//	int r = Mathf.RoundToInt(col.bounds.size.x * WidthPixel / WidthWorld);

	//	int px, nx, py, ny, d;
	//	for (int i = 0; i <= r; i++)
	//	{
	//		d = Mathf.RoundToInt(Mathf.Sqrt(r * r - i * i));
	//		for (int j = 0; j <= d; j++)
	//		{
	//			px = c.x + i;
	//			nx = c.x - i;
	//			py = c.y + j;
	//			ny = c.y - j;

	//			cloneTexture.SetPixel(px, py, Color.clear);
	//			cloneTexture.SetPixel(nx, py, Color.clear);
	//			cloneTexture.SetPixel(px, ny, Color.clear);
	//			cloneTexture.SetPixel(nx, ny, Color.clear);
	//		}
	//	}

	//	cloneTexture.Apply();
	//	//TODO removing this seems tripple performance with no consequences
	//	//UpdateTexture();
	//	Destroy(gameObject.GetComponent<PolygonCollider2D>());
	//	gameObject.AddComponent<PolygonCollider2D>();
		


	//	StartCoroutine("RebuildCollider");
		
	//}

	//void UpdateTexture()
	//{
	//	sr.sprite = Sprite.Create(cloneTexture,
	//						new Rect(0, 0, cloneTexture.width, cloneTexture.height),
	//						new Vector2(0.5f, 0.5f), 
	//						50f
	//						);
	//}

	//Vector2Int World2Pixel(Vector2 pos)
	//{
	//	Vector2Int v = Vector2Int.zero;

	//	var dx = (pos.x - transform.position.x);
	//	var dy = (pos.y - transform.position.y);

	//	v.x = Mathf.RoundToInt(0.5f * WidthPixel + dx * (WidthPixel / WidthWorld));
	//	v.y = Mathf.RoundToInt(0.5f * HeightPixel + dy * (HeightPixel / HeightWorld));

	//	return v;
	//}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{

	//	if (!collision.CompareTag("Explosion"))
	//		return;
	//	if (!collision.GetComponent<Collider2D>())
	//		return;

	//	Drill(collision.GetComponent<Collider2D>());
	//	Destroy(collision.gameObject, drillTime);
	//	StartCoroutine("ResetCanThrow");
		
		
	//}

	//IEnumerator ResetCanThrow()
	//{
	//	yield return new WaitForSeconds(drillTime + 0.5f);
	//		player.CanThrow = true;
	//}

	//public void StopReset()
	//{
	//	//TODO THIS IS HORRIBLE BUT IM TIRED
	//	StopCoroutine("ResetCanThrow");
	//}

	//IEnumerator RebuildCollider()

 //   {
	//	yield return new WaitForSeconds(drillTime);
	
	//}
}
