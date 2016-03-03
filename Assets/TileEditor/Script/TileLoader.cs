using UnityEngine;
using System.Collections;

public class TileLoader : MonoBehaviour {
	void Awake() {
		GameObject.DontDestroyOnLoad(gameObject);
	}
}
