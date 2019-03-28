using UnityEditor;
using UnityEngine;
using System;

public class Rename_EditorWindow : EditorWindow
{
	#region Variables

	//public

	//private
	private string NewName;

	private GameObject[] ObjsToRename = new GameObject[0];

	private bool AddNumbering;

	#endregion

	#region Unity Functions

	public static void LaunchEditor()
	{
		var window = GetWindow<Rename_EditorWindow>("Rename Objects");

		window.Show();
	}

	private void OnGUI()
	{
		ObjsToRename = Selection.gameObjects;

		DrawLayout();
		
		Repaint();
	}

	

	#endregion

	#region My Functions

	private void RenameThemAll()
	{
		
	}

	private void DrawLayout()
	{
		GUILayout.Space(10);

		var centered = GUI.skin.GetStyle("Label");

		centered.alignment = TextAnchor.MiddleCenter;

		GUILayout.Label("Number of Objects to Rename:" + ObjsToRename.Length, centered);

		EditorGUILayout.BeginVertical(EditorStyles.helpBox);

		EditorGUILayout.BeginHorizontal(EditorStyles.boldLabel);
		EditorGUILayout.LabelField("New Name For Objects");
		NewName = EditorGUILayout.TextField(NewName);
		EditorGUILayout.EndHorizontal();

		GUILayout.Space(10);

		EditorGUILayout.BeginHorizontal(EditorStyles.boldLabel);
		EditorGUILayout.LabelField("Numbred");
		AddNumbering = EditorGUILayout.Toggle(AddNumbering);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.EndVertical();

		GUILayout.Space(12);

		if (GUILayout.Button("Rename Selected Objects") && ObjsToRename.Length > 0)
		{
			RenameThemAll();
		}
	}

	#endregion
}
