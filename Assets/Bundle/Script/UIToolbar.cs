using UnityEngine;
using System.Collections;

public class UIToolbar : MonoBehaviour, IFageUIComponent {
	public	void OnUIInstantiate(FageUIMem mem, params object[] param) {}
	public	void OnUIDestroy(FageUIMem mem) {}
	public	void OnSwitchOut(FageUIMem mem) {}
	public	void OnSwitchIn(FageUIMem mem) {}
	public	void OnUIPause(FageUIMem mem) {}
	public	void OnUIResume(FageUIMem mem, params object[] param) {}
	public	GameObject GetGameObject() {
		return gameObject;
	}

	public	void OnClickNew() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UINew"));
	}

	public	void OnClickTile() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UITile"));
	}

	public	void OnClickOverlay() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UIOverlay"));
	}

	public	void OnClickTerrain() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UITerrain"));
	}

	public	void OnClickSave() {

	}

	public	void OnClickView() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UIView"));
	}
}
