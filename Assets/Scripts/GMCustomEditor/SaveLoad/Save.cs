using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save : MonoBehaviour
{
	#region Variables

	//public

	public static Save Instance;

	//private

	private string JsonSaveLocation;

	private string BinarySaveLocation;

	#endregion

	#region UnityFunctions

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;

			JsonSaveLocation = Application.streamingAssetsPath + "\\JsonSaveFile.json";

			BinarySaveLocation = Application.streamingAssetsPath + "\\BinarySaveFile.dat";
		}
		else
		{
			Destroy(this);
		}

	}

	#endregion

	#region MyFunctions

	public void SaveData(GameData gd)
	{
		Debug.Log("save");

#if UNITY_EDITOR
		var jsonString = JsonUtility.ToJson(gd);

		File.WriteAllText(JsonSaveLocation, jsonString);

#else

		var BF = new BinaryFormatter();
		
		var Hash = new Hashtable
		{
			{ "Player Name",gd.PlayerName},
			{"Health",gd.Health },
			{"Postion",gd.Pos }
		};

		var fs = new FileStream(BinarySaveLocation, FileMode.OpenOrCreate, FileAccess.ReadWrite);

		BF.Serialize(fs, Hash);

		fs.Close();

#endif
	}

	#endregion
}
