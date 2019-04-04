using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StairMaster_Editor : EditorWindow
{
	#region Variables

	//public

	//private

	private bool x, y, z;

	private float Offset;

	private int gridSize;

	private GameObject[] ObjsToSnap = new GameObject[0];

	#endregion

	#region Unity Functions

	private void OnGUI()
	{
		ObjsToSnap = Selection.gameObjects;

		DrawLayout();

		Repaint();
	}

	#endregion

	#region My Functions
	/// <summary>
	/// Draws the window 
	/// </summary>
	public static void LaunchEditor()
	{
		var window = GetWindow<StairMaster_Editor>("Snap to Grid");

		window.Show();
	}

	/// <summary>
	/// Sorts and then loops through to set transforms 
	/// depending on toggled axises
	/// </summary>
	private void SetStairs()
	{
		Array.Sort(ObjsToSnap, delegate (GameObject goA, GameObject goB) { return goB.GetInstanceID().CompareTo(goA.GetInstanceID()); });

		var index = 0;

		foreach(GameObject go in ObjsToSnap)
		{
			go.transform.position = Vector3.zero;
			
			go.transform.position = new Vector3(Offset * index * (x ? 1 : 0), Offset * index * (y ? 1 : 0), Offset * index * (z ? 1 : 0));
			
			index++;
		}

		EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
	}

	/// <summary>
	/// Draws the custom layout of my window
	/// </summary>
	private void DrawLayout()
	{
		EditorGUILayout.BeginVertical();

		var labelCentered = GUI.skin.GetStyle("Label");

		labelCentered.alignment = TextAnchor.MiddleCenter;
		
		EditorGUILayout.LabelField("Number of Selected Objects:" + ObjsToSnap.Length, labelCentered);

		EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"));
		
		EditorGUILayout.LabelField("Grid Directions", labelCentered);

		EditorGUILayout.BeginHorizontal();

		var toggleCentered = GUI.skin.GetStyle("Toggle");

		toggleCentered.alignment = TextAnchor.MiddleCenter;

		GUILayout.Label("x",labelCentered);
		x = EditorGUILayout.Toggle(x, toggleCentered);

		GUILayout.Label("y",labelCentered);
		y = EditorGUILayout.Toggle(y, toggleCentered);

		GUILayout.Label("z",labelCentered);
		z = EditorGUILayout.Toggle(z, toggleCentered);

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();

		GUILayout.Label("Distance Between Objects");
		Offset = EditorGUILayout.Slider(Offset,0,10);

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();

		GUILayout.Label("Grid Width");
		gridSize = EditorGUILayout.IntSlider(gridSize, 0, 10);

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.EndVertical();

		if(GUILayout.Button("Snap to Grid"))
		{
			SetStairs();
		}

		EditorGUILayout.EndVertical();
	}

	#endregion
}
