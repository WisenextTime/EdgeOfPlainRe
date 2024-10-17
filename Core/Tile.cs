using System.Net.Mime;
using System.Reflection;
using Edge_Of_Plain.Core.Game;
using Raylib_cs;
namespace Edge_Of_Plain.Core;

public class Tile
{
	public string Id { get; }
	
	public Image Image;
	private Texture2D? _texture;
	public Texture2D Texture{
		get { return _texture ??= Raylib.LoadTextureFromImage(Image); }
	}
	
	/// <summary>
	/// This will affect the acceleration and max velocity of units.
	/// </summary>
	public float Roughness { get; set; } = 1f;
	
	/// <summary>
	/// The terrain of tile.
	/// It uses binary mask to determine which units are passable.
	/// <list type="mask">
	///		<item>0:AntiLand</item>
	///		<item>1:AntiWater</item>
	///		<item>(Enable 0 and 1 will not prevent Hover units)</item>
	///		<item>2:AntiHover(Anti both Land and Water units)</item>
	///		<item>3:AntiAir</item>
	/// </list>
	/// </summary>
	public uint Terrain = 0b_0000;
	
	public float Temperature = 5f;
	public float Humidity = 5f;

	public bool CanLighted = false;
	public Image LightImage;

	private Texture2D? _lightTexture;
	public Texture2D LightTexture
	{
		get { return _lightTexture ??= Raylib.LoadTextureFromImage(LightImage); }
	}
	public const float LightIntensity = 1f;
	public Color LightColor = Color.White;

	
	public Tile(string id,string mod)
	{
		Id = id;
		if(mod == "Index")
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = $"Edge_Of_Plain.Assets.Textures.Tiles.{id}";
			var stream = assembly.GetManifestResourceStream($"{resourceName}.png");
			if (stream != null)
			{
				var imageData = new byte[stream.Length];
				_ = stream.Read(imageData, 0, imageData.Length);
				Image = Raylib.LoadImageFromMemory(".png", imageData);
			}
			else
			{
				throw new FileNotFoundException($"Could not find {resourceName}");
			}
			resourceName = $"Edge_Of_Plain.Assets.Textures.Tiles.{id}lLight";
			stream = assembly.GetManifestResourceStream($"{resourceName}.png");
			if (stream != null)
			{
				var imageData = new byte[stream.Length];
				_ = stream.Read(imageData, 0, imageData.Length);
				LightImage = Raylib.LoadImageFromMemory(".png", imageData);
			}
			stream?.Close();
		}
		else
		{
			var modDir =Global.GetGlobal().GamePath + "Mods/" + mod + "/";
			Image = Raylib.LoadImage(modDir + "Assets/Textures/Tiles/" + id + ".png");
			LightImage = Raylib.LoadImage(modDir + "Assets/Textures/Tiles/" + id + "_light.png");
		}
	}
}