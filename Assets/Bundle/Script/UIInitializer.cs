using UnityEngine;
using System.Collections;

public class UIInitializer : MonoBehaviour, IFageUIComponent {
	public	TextAsset	tileConfig;

	public	void OnUIInstantiate(FageUIMem mem, params object[] param) {
		var config = TileConfig.LoadFromText(tileConfig.text);
		Debug.Log(config);
	}

	public	void	OnUIDestroy(FageUIMem mem) {
		
	}

	public	void	OnSwitchOut(FageUIMem mem) {
		
	}

	public	void	OnSwitchIn(FageUIMem mem) {
		
	}

	public	void	OnUIPause(FageUIMem mem) {
		
	}

	public	void	OnUIResume(FageUIMem mem, params object[] param) {
		
	}

	public	GameObject	GetGameObject() {
		return gameObject;
	}
}
