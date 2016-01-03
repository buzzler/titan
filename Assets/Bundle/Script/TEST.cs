using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {
	public	Vector2 worldPos;
	private	float cos45;
	private	float sin45;

	// Use this for initialization
	void Start () {
		cos45 = Mathf.Cos(45);
		sin45 = Mathf.Cos(45);
	}
	
	// Update is called once per frame
	void Update () {
		worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		worldPos.y *= 2;
		float _x = cos45 * worldPos.x - sin45 * worldPos.y;
		float _y = sin45 * worldPos.x + cos45 * worldPos.y;
		worldPos.x = Mathf.Floor(_x*2f);
		worldPos.y = Mathf.Floor(_y*2f);

//		RaycastHit2D[] hits = Physics2D.RaycastAll(worldPos, Vector2.zero);
//		if (hits != null && hits.Length > 0 && hits[0].collider != null) {
//			Debug.Log(hits[0].collider.name);
//		}
	}
}
