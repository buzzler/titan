﻿using UnityEngine;
using System.Collections;

public class UIOverlay : MonoBehaviour, IFageUIComponent {
	public	void OnUIInstantiate(FageUIMem mem, params object[] param) {}
	public	void OnUIDestroy(FageUIMem mem) {}
	public	void OnSwitchOut(FageUIMem mem) {}
	public	void OnSwitchIn(FageUIMem mem) {}
	public	void OnUIPause(FageUIMem mem) {}
	public	void OnUIResume(FageUIMem mem, params object[] param) {}
	public	GameObject GetGameObject() {
		return gameObject;
	}
	
	public	void OnClickClose() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UIToolbar"));
	}
	
	public	void OnClickAdd() {
		
	}
	
	public	void OnClickOk() {
		FageUIManager.Instance.Change(FageUIRoot.Instance.FindUISet("UIToolbar"));
	}
}
