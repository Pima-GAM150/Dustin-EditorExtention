using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GM))]
public class GMInspector : Editor
{
	#region Variables

	//public

	//private

	#endregion

	#region UnityFunctions

	public override void OnInspectorGUI()
	{
		var gm = target as GM;

		//GameData

		var centered = GUI.skin.GetStyle("Label");

		centered.alignment = TextAnchor.MiddleCenter;

		GUILayout.Label("Game Data", centered);

		centered.alignment = TextAnchor.MiddleLeft;

		GUILayout.BeginHorizontal();

		GUILayout.BeginVertical();

		GUILayout.Label("PlayerName");

		GUILayout.Label("Health");

		GUILayout.Label("Position");

		GUILayout.EndVertical();

		GUILayout.BeginVertical();

		gm.GD.PlayerName = GUILayout.TextField(gm.GD.PlayerName);

		gm.GD.Health = EditorGUILayout.IntField(gm.GD.Health);

		GUILayout.BeginHorizontal();

		centered.alignment = TextAnchor.MiddleRight;

		GUILayout.Label("x");
		gm.GD.Pos[0] = EditorGUILayout.FloatField(gm.GD.Pos[0]);

		GUILayout.Label("y");
		gm.GD.Pos[1] = EditorGUILayout.FloatField(gm.GD.Pos[1]);

		GUILayout.Label("z");
		gm.GD.Pos[2] = EditorGUILayout.FloatField(gm.GD.Pos[2]);

		GUILayout.EndHorizontal();

		GUILayout.EndVertical();

		GUILayout.EndHorizontal();

		//Buttons

		GUILayout.BeginHorizontal();

		if (GUILayout.Button("Save"))
		{
			if (gm.GD == null)
			{
				gm.GD = new GameData();
			}

			gm.SaveGameData();
		}
		if (GUILayout.Button("Load"))
		{
			if (gm.GD == null)
			{
				gm.GD = new GameData();
			}

			gm.LoadGameData();
		}

		GUILayout.EndHorizontal();
	}

	#endregion

	#region MyFunctions



	#endregion
}
