using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Accesories
{
    public class FrozenFlareSoul : ModItem
    {
        public override void SetDefaults()
        {
		    item.damage = 40;
			item.shootSpeed = 10f;
			item.knockBack = 5;
            item.width = 22;
            item.height = 24;
            item.maxStack = 1;
            item.value = Terraria.Item.sellPrice(0, 12, 50, 0);
            item.rare = 6;
					item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flarefrost Core");
            Tooltip.SetDefault("Getting hit causes fire and frost beams to strike");
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
	{
		if (player.immune)
		{
					if (Main.rand.Next(6) == 0)
			{
		 	    for (int l = 0; l < 1; l++)
				{
             
					float x = (float)Main.mouseX + Main.screenPosition.X;
					float y = (float)Main.mouseY + Main.screenPosition.Y;
					Vector2 vector = new Vector2(x, y);
					float num15 = player.position.X + (float)(player.width / 2) - vector.X;
					float num16 = player.position.Y + (float)(player.height / 2) - vector.Y;
					num15 += (float)Main.rand.Next(-100, 101);
					int num17 = 22;
					float num18 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
					num18 = (float)num17 / num18;
					num15 *= num18;
					num16 *= num18;
					int num19 = Projectile.NewProjectile(x, y, num15, num16, mod.ProjectileType("Flame"), 38, 2f, player.whoAmI, 0f, 0f);
					Main.projectile[num19].ai[1] = player.position.Y;
					Main.projectile[num19].tileCollide = false;
				}
			}
						if (Main.rand.Next(8) == 0)
			{
		 	    for (int l = 0; l < 1; l++)
				{
             
					float x = (float)Main.mouseX + Main.screenPosition.X;
					float y = (float)Main.mouseY + Main.screenPosition.Y;
					Vector2 vector = new Vector2(x, y);
					float num15 = player.position.X + (float)(player.width / 2) - vector.X;
					float num16 = player.position.Y + (float)(player.height / 2) - vector.Y;
					num15 += (float)Main.rand.Next(-100, 101);
					int num17 = 22;
					float num18 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
					num18 = (float)num17 / num18;
					num15 *= num18;
					num16 *= num18;
					int num19 = Projectile.NewProjectile(x, y, num15, num16, mod.ProjectileType("Ice"), 38, 2f, player.whoAmI, 0f, 0f);
					Main.projectile[num19].ai[1] = player.position.Y;
					Main.projectile[num19].tileCollide = false;
				}
			}
}

}
	           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			            recipe.AddIngredient(null, ("FieryTissue"), 20);
            recipe.AddIngredient(null, ("FrigidFragment"), 20);
						            recipe.AddIngredient(null, ("DuskSteel"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
}

}