using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Fancy_Editor : EditorWindow
{
	#region Variables

	//public

	//private

	TemplateContainer Layout;

	TextField input;

	Button doTheThing;

	string newName;

	Vector3 pos;

	GameObject[] selected;
	#endregion

	#region Unity Functions

	private void OnEnable()
	{
		Init();
	}

	private void OnGUI()
	{
		selected = Selection.gameObjects;
	}

	private void OnDisable()
	{
		doTheThing.clickable.clickedWithEventInfo -= GoDoThatThing();
	}
	#endregion

	#region My Functions

	public static void LaunchEditor()
	{
		var window = GetWindow(typeof(Fancy_Editor));
	}

	private void Init()
	{
		var uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/USS attempt/Editor/MyWindow.uxml");

		Layout = uiAsset.CloneTree();

		var myStyle = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/USS attempt/Editor/MyStylesheet.uss");

		var myBox = new Box { name = "myBox" };

		myBox.AddToClassList("My_Fancy_box");

		input = new TextField("New Name");

		myBox.Add(input);

		var row = new VisualElement { name = "row"};

		row.Add(new Label("Position"));
		
		var x = new FloatField("x");
		var y = new FloatField("y");
		var z = new FloatField("z");

		x.RegisterCallback<ChangeEvent<float>>(l => pos.x = x.value);
		y.RegisterCallback<ChangeEvent<float>>(l => pos.y = y.value);
		z.RegisterCallback<ChangeEvent<float>>(l => pos.z = z.value);

		row.Add(x);
		row.Add(y);
		row.Add(z);

		myBox.Add(row);

		myBox.Q<TextField>().RegisterCallback<ChangeEvent<string>>(l => newName = (l.target as TextField).value);

		doTheThing = new Button();

		doTheThing.AddToClassList("Fancy__button");

		doTheThing.text = "Do the thing...";

		///Button Click methods????\\\

		//doTheThing.clickable = new Clickable(delegate () { DoTheThing(); });


		//doTheThing.clickable = new Clickable(l => DoTheThing());


		//doTheThing.clickable = new Clickable(delegate () { DoTheThing(); }, 1, 1);


		//doTheThing.clickable.clicked += DoTheThing;


		//////Finally something worked
		doTheThing.clickable.clickedWithEventInfo += GoDoThatThing();


		///Button Click methods????\\\
		
		myBox.Add(doTheThing);

		Layout.Add(myBox);

		rootVisualElement.styleSheets.Add(myStyle);

		rootVisualElement.Add(Layout);
	}

	/*
	 private void DoTheThing()
	 {
		 Debug.Log("Grrr!");
	 }
		 
	*/


	private void DoThatThing()
	{
		Debug.Log("Grrr!");

		int i = 0;

		foreach(GameObject go in selected)
		{
			go.name = newName + "  :)";

			go.transform.position = pos * i;

			i++;
		}

		EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
	}
	
	private Action<EventBase> GoDoThatThing()
	{
		return l => DoThatThing();
	}

	#endregion
}