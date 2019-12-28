using Microsoft.Xna.Framework;
using NightmaresTMod.Materials.Bars;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace NightmaresTMod.Tiles.Bars
{
	public class NightmariumBarTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileShine[Type] = 1100;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);

			AddMapEntry(new Color(30, 0, 80), Language.GetText("MapObject.MetalBar")); // localized text for "Metal Bar"
		}

		public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
			if (style == 0) // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<NightmariumBar>());
			}
			return base.Drop(i, j);
		}
	}
}