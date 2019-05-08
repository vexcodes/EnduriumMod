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
                float x = player.position.X + (float)Main.rand.Next(-200, 200);
                float y = player.position.Y + (float)Main.rand.Next(-200, 200);
                Vector2 vector = new Vector2(x, y);
                float num13 = (Main.mouseX + Main.screenPosition.X) - vector.X;
                float num14 = (Main.mouseY + Main.screenPosition.Y) - vector.Y;
                num13 += (float)Main.rand.Next(-100, 101);
                int num15 = 23;
                float num16 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
                num16 = (float)num15 / num16;
                num13 *= num16;
                num14 *= num16;
                if (Main.rand.Next(8) == 0)
                {
                    int num18 = Projectile.NewProjectile(x, y, num13, num14, mod.ProjectileType("Ice"), 30, 5f, player.whoAmI, 0f, 0f);
                    Main.projectile[num18].ai[1] = player.position.Y;
                    Main.projectile[num18].tileCollide = false;
                }
                if (Main.rand.Next(8) == 0)
                {
                    int num17 = Projectile.NewProjectile(x, y, num13, num14, mod.ProjectileType("HellshardScepter"), 30, 5f, player.whoAmI, 0f, 0f);
                    Main.projectile[num17].ai[1] = player.position.Y;
                    Main.projectile[num17].tileCollide = false;
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