using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Shaders;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace EnduriumMod.Items
{
    public class GalaxyFruit : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 62;
            item.height = 62;
            item.useTime = 20;

            item.useAnimation = 20;
            item.useStyle = 2;
            item.noMelee = true;
            item.value = 1000000;
            item.UseSound = SoundID.Item67;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.LifeFruit, 5);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddIngredient(null, ("CoreofCreation"), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Fruit");
            Tooltip.SetDefault("Increases max life by 100");
        }
        public override bool CanUseItem(Player player)
        {
            return ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).bonusHealth <= 99;
        }
        public override bool UseItem(Player player)
        {
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).bonusHealth += 100;
            int num3 = 0;
            for (int num997 = 0; num997 < 20; num997 = num3 + 1)
            {
                int num998 = Dust.NewDust(player.position, player.width, player.height, 27, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num998].position = player.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)player.width / 2f;
                Dust dust3 = Main.dust[num998];
                dust3.velocity *= 2.1f;
                Main.dust[num998].noGravity = true;
                Main.dust[num998].fadeIn = 1.5f;

                num3 = num997;
            }
            for (int num999 = 0; num999 < 15; num999 = num3 + 1)
            {
                int num1000 = Dust.NewDust(player.position, player.width, player.height, 27, 0f, 0f, 0, default(Color), 3.7f);
                Main.dust[num1000].position = player.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy((double)player.velocity.ToRotation(), default(Vector2)) * (float)player.width / 2f;
                Main.dust[num1000].noGravity = true;
                Dust dust3 = Main.dust[num1000];
                dust3.velocity *= 1.3f;
                num3 = num999;
            }
            float num1001 = (float)Main.rand.NextDouble() * 6.28318548f;
            float num1002 = (float)Main.rand.NextDouble() * 6.28318548f;
            float num1003 = (float)Main.rand.NextDouble() * 6.28318548f;
            float num1004 = 8f + (float)Main.rand.NextDouble() * 7f;
            float num1005 = 8f + (float)Main.rand.NextDouble() * 7f;
            float num1006 = 8f + (float)Main.rand.NextDouble() * 7f;
            float num1007 = num1004;
            if (num1005 > num1007)
            {
                num1007 = num1005;
            }
            if (num1006 > num1007)
            {
                num1007 = num1006;
            }
            for (int num1008 = 0; num1008 < 200; num1008 = num3 + 1)
            {
                int num1009 = 135;
                float scaleFactor14 = num1007;
                if (num1008 > 50)
                {
                    scaleFactor14 = num1005;
                }
                if (num1008 > 100)
                {
                    scaleFactor14 = num1004;
                }
                if (num1008 > 150)
                {
                    scaleFactor14 = num1006;
                }
                int num1010 = Dust.NewDust(player.position, 27, 27, num1009, 0f, 0f, 27, default(Color), 1f);
                Vector2 vector138 = Main.dust[num1010].velocity;
                Main.dust[num1010].position = player.Center;
                vector138.Normalize();
                vector138 *= scaleFactor14;
                if (num1008 > 150)
                {
                    vector138.Y *= 0.5f;
                    vector138 = vector138.RotatedBy((double)num1003, default(Vector2));
                }
                else if (num1008 > 100)
                {
                    vector138.X *= 0.5f;
                    vector138 = vector138.RotatedBy((double)num1001, default(Vector2));
                }
                else if (num1008 > 50)
                {
                    vector138.Y *= 0.5f;
                    vector138 = vector138.RotatedBy((double)num1002, default(Vector2));
                }
                Dust dust3 = Main.dust[num1010];
                dust3.velocity *= 0.4f;
                dust3 = Main.dust[num1010];
                dust3.velocity += vector138;
                if (num1008 <= 200)
                {
                    Main.dust[num1010].scale = 2f;
                    Main.dust[num1010].noGravity = true;
                    Main.dust[num1010].fadeIn = Main.rand.NextFloat() * 2f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[num1010].fadeIn = 2.5f;
                    }
                    Main.dust[num1010].noLight = true;
                    if (num1008 < 100)
                    {
                        dust3 = Main.dust[num1010];
                        dust3.position += Main.dust[num1010].velocity * 26f;
                        dust3 = Main.dust[num1010];
                        dust3.velocity *= -1f;
                    }
                }
                num3 = num1008;
            }


            return true;
        }
    }
}