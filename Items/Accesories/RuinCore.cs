using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class RuinCore : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = 3;
            item.accessory = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("NatureEssence"), 15);
            recipe.AddTile(mod.TileType("AncientAltar"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruin Core");
            Tooltip.SetDefault("Grants immunity to poison and increases movement speed by 20%\nYou emit a faint green glow");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Poisoned] = true;
            player.moveSpeed += 0.20f;
            Lighting.AddLight(player.Center, 0f, 0.9f, 0f);
            int num998 = Dust.NewDust(player.position, player.width, player.height, 89, 0, 0, 0, Color.Green, 0.5f);
            Dust dust3 = Main.dust[num998];
            dust3.velocity.Y *= 3.1f;
            Main.dust[num998].noGravity = true;
            Main.dust[num998].fadeIn = 0.8f;
        }
    }
}