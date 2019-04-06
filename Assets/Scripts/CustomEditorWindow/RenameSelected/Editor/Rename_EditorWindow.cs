using UnityEditor;
using UnityEditor.SceneManagement;
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

	private bool ByInstanceID;

	#endregion

	#region Unity Functions

	private void OnGUI()
	{
		ObjsToRename = Selection.gameObjects;

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
		var window = GetWindow<Rename_EditorWindow>("Rename Objects");

		window.Show();
	}

	/// <summary>
	/// renames the selected objects to what i entered
	/// </summary>
	private void RenameThemAll()
	{
		var i = 1;

		SortSelected();

		foreach(GameObject go in ObjsToRename)
		{
			go.name = "";

			go.name = NewName + " " + (AddNumbering ? i.ToString() : "");

			i++;
		}

		EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
	}

	/// <summary>
	/// Sorts the array of selected items by instance id
	/// </summary>
	private void SortSelected()
	{
		if (ByInstanceID)
		{
			Array.Sort(ObjsToRename, delegate (GameObject goA, GameObject goB) { return goB.GetInstanceID().CompareTo(goA.GetInstanceID()); });
		}
		else
		{
			Array.Sort(ObjsToRename, delegate (GameObject goA, GameObject goB) { return goA.name.CompareTo(goB.name); });
		}
	}
	
	/// <summary>
	/// Draws the custom layout of my window
	/// </summary>
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

		EditorGUILayout.LabelField("By Instance ID");
		ByInstanceID = EditorGUILayout.Toggle(ByInstanceID);

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
