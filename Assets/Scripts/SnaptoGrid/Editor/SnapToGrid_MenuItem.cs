using UnityEditor;

public class SnapToGrid_MenuItem
{
	#region My Functions

	[MenuItem("Dustin's Tools/SnapToGrid/Open Window")]
	public static void OpenWindow()
	{
		Rename_EditorWindow.LaunchEditor();
	}

	#endregion
}
