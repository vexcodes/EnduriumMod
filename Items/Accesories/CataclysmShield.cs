using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class CataclysmShield : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 100;
            item.width = 34;
            item.height = 42;
            item.value = Terraria.Item.buyPrice(1, 15, 50, 0);
            item.rare = 9;
            item.accessory = true;
            item.defense = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cataclysm Bulwark");
            Tooltip.SetDefault("Grants immunity to knockback and fire blocks\nGrants immunity to most debuffs\nIncreases movement speed and length of invincibility after taking damage\nAll attacks inflict On Fire!\nGetting hit releases demonic energy");
        }// and Dragon's Breath Super Debuff


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[46] = true;
            player.buffImmune[44] = true;
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true;
            player.buffImmune[36] = true;
            player.buffImmune[30] = true;
            player.buffImmune[20] = true;
            player.buffImmune[32] = true;
            player.buffImmune[31] = true;
            player.buffImmune[35] = true;
            player.buffImmune[23] = true;
            player.buffImmune[22] = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).EthernalNecklace = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).DemonicHurt = true;
            player.moveSpeed += 0.5f;
            player.accRunSpeed *= 1.5f;
            player.longInvince = true;
            player.buffImmune[mod.BuffType("AcidPlague")] = true;
            player.buffImmune[BuffID.OnFire] = true;
            if (player.immune)
            {
                if (Main.rand.Next(3) == 0)
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
                        int num19 = Projectile.NewProjectile(x, y, num15, num16, mod.ProjectileType("DevilBeam"), 100, 2f, player.whoAmI, 0f, 0f);
                        Main.projectile[num19].ai[1] = player.position.Y;
                        Main.projectile[num19].tileCollide = false;
                    }
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CataclysmNecklace"));
            recipe.AddIngredient(1613);
            recipe.AddIngredient(null, ("SoulofDusk"), 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
