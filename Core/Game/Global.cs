using System.Runtime.InteropServices;
using Edge_Of_Plain.Core.Content;

namespace Edge_Of_Plain.Core.Game;

public class Global
{
	private static Global? _instance;

	public Dictionary<string, Tile> Tiles = new();
	
	//Setting
	public int OsPlatformId;
	public string GamePath = "";
	
	private Global()
	{
		_instance = this;
	}

	public static Global GetGlobal()
	{
		return _instance ??= new Global();
	}
	
}