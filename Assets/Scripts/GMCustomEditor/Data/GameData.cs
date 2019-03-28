using System;

[Serializable]
public class GameData 
{
	public string PlayerName;
	public int Health;
	public float[] Pos;

	public GameData()
	{
		PlayerName = "Name";
		Health = 100;
		Pos = new float[3] { 0, 0, 0 };
	}

	public GameData(string name, int health, float[] position )
	{
		PlayerName = name;
		Health = health;
		Pos = position;
	}
}
