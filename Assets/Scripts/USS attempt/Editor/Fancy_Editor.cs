using System;
using UnityEngine.Experimental;
using UnityEditor.Experimental;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

public class Fancy_Editor : EditorWindow
{
	#region Variables

	//public

	//private

	#endregion

	#region Unity Functions

	private void OnGUI()
	{

		DrawLayout();

		Repaint();
	}
	#endregion

	#region My Functions

	public static void LaunchEditor()
	{
		var win = GetWindow<Fancy_Editor>();

		win.Show();

	}

	private void DrawLayout()
	{

	}
	#endregion
}
