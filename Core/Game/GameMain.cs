using Edge_Of_Plain.Core.Content;
using Raylib_cs;

namespace Edge_Of_Plain.Core.Game;

internal static class GameMain
{
	public static void Main()
	{
		Tiles.PreLoadTiles();
		Raylib.InitWindow(1280, 800, "Game");
		while (!Raylib.WindowShouldClose())
		{
			
			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.White);

			Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
			foreach (var tile in Global.GetGlobal().Tiles.Select((tile, index) => new { tile, index }))
			{
				Raylib.DrawTexture(tile.tile.Value.Texture, tile.index * 32, 0, Color.White);
			}
			Raylib.EndDrawing();
		}
		Raylib.CloseWindow();
	}
}