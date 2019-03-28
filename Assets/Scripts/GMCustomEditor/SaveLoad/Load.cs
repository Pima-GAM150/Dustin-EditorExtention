using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load : MonoBehaviour
{
	#region Variables

	//public

	public static Load Instance;

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

	public void LoadGameData(ref GameData gd)
	{
		Debug.Log("Load");

#if UNITY_EDITOR

		var jsonString = File.ReadAllText(JsonSaveLocation);

		if (jsonString == null)
		{
			gd = new GameData();
		}
		else
		{
			gd = JsonUtility.FromJson<GameData>(jsonString);
		}

#else
		var BF = new BinaryFormatter();
		var Hash = new Hashtable();
		var fs = new FileStream(BinarySaveLocation, FileMode.Open, FileAccess.ReadWrite);

		Hash = (Hashtable)BF.Deserialize(fs);

		fs.Close();

		foreach (DictionaryEntry de in Hash)
		{
			switch (de.Key)
			{
				case "Player Name":
					gd.PlayerName = de.Value as string;
					break;
				case "Health":
					gd.Health = (int)de.Value;
					break;
				case "Position":
					gd.Pos = de.Value as float[];
					break;
			}
		}
#endif
			}

	#endregion
}
