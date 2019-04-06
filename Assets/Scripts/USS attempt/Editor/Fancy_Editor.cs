using System;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


using Toolbar = UnityEditor.UIElements.Toolbar;
using PopupWindow = UnityEngine.UIElements.PopupWindow;

public class Fancy_Editor : EditorWindow
{
	#region Variables

	//public

	//private

	Button doTheThing;


	#endregion

	#region Unity Functions

	private void OnEnable()
	{
		Init();
	}

	private void OnGUI()
	{
		Repaint();
	}

	private void OnDisable()
	{
		
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

	private void Init()
	{
		var root = this.rootVisualElement;

		var MyBox = new Box();

		MyBox.AddToClassList("My_Fancy_box");

		doTheThing = new Button
		{
			text = "Do The Thing",

			clickable = new Clickable(l => DoTheThing())
		};

		doTheThing.AddToClassList("Fancy__button");

		MyBox.Add(doTheThing);

		root.Add(MyBox);
	}

	private void DoTheThing()
	{
		Debug.Log("grrrrr");
	}

	#endregion
}