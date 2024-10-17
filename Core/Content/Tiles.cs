using Edge_Of_Plain.Core.Game;
using Raylib_cs;

namespace Edge_Of_Plain.Core.Content;

public static class Tiles
{
	public static void PreLoadTiles()
	{
		Global.GetGlobal().Tiles.Add("Grass",new Tile("Grass","Index"){Terrain = 0b_0010 });
		Global.GetGlobal().Tiles.Add("Stone",new Tile("Stone","Index"){Terrain = 0b_0010, Humidity = 3f });
		Global.GetGlobal().Tiles.Add("Ice",new Tile("Ice","Index"){Terrain = 0b_0010, Humidity = 6f, Roughness = 1.5f });
		Global.GetGlobal().Tiles.Add("Mud",new Tile("Mud","Index"){Terrain = 0b_0010, Humidity = 7f,Temperature = 2f, Roughness = 0.5f });
		Global.GetGlobal().Tiles.Add("Water", new Tile("Water","Index"){Terrain = 0b_0001, Humidity = 9f });
		Global.GetGlobal().Tiles.Add("Lava", new Tile("Lava","Index")
		{
			Terrain = 0b_0111, Humidity = 0f, Temperature = 10f,
			CanLighted = true, LightColor = Color.Red
		});
		Global.GetGlobal().Tiles.Add("FluorescentGrass",new Tile("FluorescentGrass","Index")
		{
			Terrain = 0b_0010,
			CanLighted = true, LightColor = new Color(0,255,255,255)
		});
		Global.GetGlobal().Tiles.Add("WaterBridge", new Tile("WaterBridge","Index"){Terrain = 0b_0000, Humidity = 9f });
	}
}