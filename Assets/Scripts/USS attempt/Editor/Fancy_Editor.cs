using System;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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
		var window = GetWindow(typeof(Fancy_Editor));
		
		var uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/USS attempt/Editor/MyWindow.uxml");

		var Layout = uiAsset.CloneTree();

		var myStyle = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/USS attempt/Editor/MyStylesheet.uss");

		window.rootVisualElement.styleSheets.Add(myStyle);

		window.rootVisualElement.Add(Layout);
	}

	private void DrawLayout()
	{

	}
	#endregion
}
