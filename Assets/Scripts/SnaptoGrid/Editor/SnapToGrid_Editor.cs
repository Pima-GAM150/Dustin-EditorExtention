using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SnapToGrid_Editor : EditorWindow
{
	#region Variables

	//public

	//private

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

	public static void LaunchEditor()
	{
		var window = GetWindow<SnapToGrid_Editor>("Snap to Grid");

		window.Show();
	}

	private void SnapToGrid()
	{

		
	}

	private void DrawLayout()
	{
		
	}

	#endregion
}
