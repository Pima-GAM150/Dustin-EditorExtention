using System;
using UnityEngine;

public class GM : MonoBehaviour
{
	#region Variables

	//public
	public static GM Instance;
	public GameData GD;

	//private

	#endregion

	#region UnityFunctions

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;

			GD = new GameData();
		}
		else
		{
			Destroy(this);
		}
	}

	#endregion

	#region MyFunctions

	public void SaveGameData()
	{
		Save.Instance.SaveData(GD);
	}

	public void LoadGameData()
	{
		Load.Instance.LoadGameData(ref GD);
	}

	#endregion
}
