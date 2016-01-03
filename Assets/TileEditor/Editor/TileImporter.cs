using UnityEngine;
using UnityEditor;
using System.IO;

public class TileImporter : EditorWindow {
	[MenuItem ("FNF Games/Tile Importer")]
	static void Init () {
		TileImporter window = (TileImporter)EditorWindow.GetWindow (typeof (TileImporter));
		window.Preset();
		window.Show();
	}

	#region draw inspector
	int			pivotX;			// pivot info
	int			pivotY;			// pivot info
	Vector2		scrollPos;		// library scroll position
	TileType	ttype;			// tile type
	string		categoryName;	// category name
	int			selectedGrid;	// selection index of grid
	int			widthGrid;		// cell of grid

	void Preset() {
		widthGrid = 2;
	}

	void OnGUI () {
		DrawPreview();
		DrawLibrary();
	}

	/// <summary>
	/// Draws the preview.
	/// </summary>
	void DrawPreview() {
		GUILayout.Label("Preview", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		EditorGUILayout.Separator();
		EditorGUILayout.TextField(AssetDatabase.GetAssetPath(selected));
		TileType tempType = ttype;
		ttype = (TileType) EditorGUILayout.EnumPopup("Base Frame", ttype);
		if (ttype != tempType)
			OnSelectionChange();
		int tempInt = pivotX;
		pivotX = EditorGUILayout.IntField("Pivot X", pivotX);
		if (pivotX != tempInt)
			OnSelectionChange();
		tempInt = pivotY;
		pivotY = EditorGUILayout.IntField("Pivot Y", pivotY);
		if (pivotY != tempInt)
			OnSelectionChange();
		EditorGUILayout.Popup(0, new string[] {"New Category", "Brick"});
		categoryName = EditorGUILayout.TextField("Category Name", categoryName);
		if (GUILayout.Button("add to library")) {
			OnClickAdd();
		}
		GUILayout.EndVertical();
		GUILayout.Box(mixed);
		GUILayout.EndHorizontal();
	}

	/// <summary>
	/// Draws the library.
	/// </summary>
	void DrawLibrary() {
		GUILayout.Label("Library", EditorStyles.boldLabel);
		EditorGUILayout.LabelField("");
		GUILayout.BeginHorizontal();
		EditorGUILayout.Popup(0, new string[] {"Brick"});
		GUILayout.Button("new", GUILayout.Width(60));
		GUILayout.Button("open", GUILayout.Width(60));
		GUILayout.Button("save", GUILayout.Width(60));
		GUILayout.EndHorizontal();
		scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
		selectedGrid = GUILayout.SelectionGrid(selectedGrid, new GUIContent[]{new GUIContent(selected), new GUIContent(selected), new GUIContent(selected), new GUIContent(selected), new GUIContent(selected)}, widthGrid);
		GUILayout.EndScrollView();
		GUILayout.BeginHorizontal();
		GUILayout.Button("remove", GUILayout.Width(60));
		GUILayout.FlexibleSpace();
		GUILayout.Label(string.Format("Cells ({0})", widthGrid));
		if (GUILayout.Button("+", GUILayout.Width(60)))
			widthGrid++;
		if (GUILayout.Button("-", GUILayout.Width(60)))
			widthGrid = Mathf.Max(1, widthGrid - 1);
		GUILayout.EndHorizontal();
	}

	#endregion

	#region draw preview
	Texture2D selected;		// selected texture in Project View
	Texture2D cube;			// cube overlay
	Texture2D plane;		// plane overlay
	Texture2D mixed;		// texture for preview

	/// <summary>
	/// Refresh Preview Texture
	/// </summary>
	void Refresh() {
		selected = Selection.activeObject as Texture2D;
		if (cube == null)
			cube = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/TileEditor/Editor/cube.png");
		if (plane == null)
			plane = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/TileEditor/Editor/plane.png");
		
		Texture2D overlay = (ttype==TileType.cube) ? cube:plane;
		
		int previewW = Mathf.Max(selected.width, overlay.width);
		int previewH = Mathf.Max(selected.height, overlay.height);
		mixed = new Texture2D(previewW, previewH);
		
		int offx = (previewW - selected.width) / 2;
		int offy = (previewH - selected.height) / 2;
		for (int y = 0 ; y < selected.height ; y++) {
			for (int x = 0 ; x < selected.width ; x++) {
				mixed.SetPixel(offx+x,offy+y, selected.GetPixel(x,y));
			}
		}
		
		offx = (previewW - overlay.width) / 2;
		offy = (previewH - overlay.height) / 2;
		for (int y = 0 ; y < overlay.height ; y++) {
			for (int x = 0 ; x < overlay.width ; x++) {
				Color c = overlay.GetPixel(x,y);
				if (c.a>0f) {
					mixed.SetPixel((int)pivotX+offx+x,(int)pivotY+offy+y, overlay.GetPixel(x,y));
				}
			}
		}
		mixed.Apply();
	}

	void OnSelectionChange() {
		if (Selection.activeObject is Texture2D) {
			Refresh ();
		}
	}

	void OnInspectorUpdate() {
		Repaint();
	}
	#endregion

	void OnClickAdd() {
		Debug.Log("Hello World");
	}

	void OnClickNew() {
	}

	void OnClickOpen() {
	}

	void OnClickSave() {
	}

	void OnClickRemove() {
	}

	void OnClickPlus() {
	}

	void OnClickMinus() {
	}
}

public	enum TileType {
	cube,
	plan
}