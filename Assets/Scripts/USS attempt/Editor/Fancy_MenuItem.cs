using System;
using UnityEditor;

public class Fancy_MenuItem
{
	#region My Functions

	[MenuItem("Dustin's Tools/Fancy Window/Open Window")]
	public static void OpenWindow()
	{
		Fancy_Editor.LaunchEditor();
	}

	#endregion
}
