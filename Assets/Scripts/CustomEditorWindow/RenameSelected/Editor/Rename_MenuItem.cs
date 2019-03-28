using UnityEditor;

public class Rename_MenuItem
{
	#region MyFunctions

	[MenuItem("Dustin's Tools/Rename Selected GameObjects/Open Window")]
	public static void OpenWindow()
	{
		Rename_EditorWindow.LaunchEditor();
	}
	#endregion
}
