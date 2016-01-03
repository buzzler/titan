using UnityEngine;
using System.Collections;

public class UIView : MonoBehaviour, IFageUIComponent {
	public	void OnUIInstantiate(FageUIMem mem, params object[] param) {}
	public	void OnUIDestroy(FageUIMem mem) {}
	public	void OnSwitchOut(FageUIMem mem) {}
	public	void OnSwitchIn(FageUIMem mem) {}
	public	void OnUIPause(FageUIMem mem) {}
	public	void OnUIResume(FageUIMem mem, params object[] param) {}
	public	GameObject GetGameObject() {
		return gameObject;
	}
	
	public	void OnClickCancel() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UIToolbar"));
	}
	
	public	void OnClickOk() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UIToolbar"));
	}
}
