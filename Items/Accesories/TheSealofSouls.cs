using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class TheSealofSouls : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 3, 0, 0);
            item.rare = 6;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Seal of Souls");
            Tooltip.SetDefault("'The soul of fallen is sealed within'\nIncreases max minions by 1\nIncreases minion damage by 14%\nIncreases minion knockback by 50%\nReduces life regeneration and max health slightly");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AncientCharm"));
            recipe.AddIngredient(null, ("GlowingScale"));
            recipe.AddIngredient(null, ("EvilHeart"));
            recipe.AddIngredient(null, ("ErodedShard"), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 -= 25;
            player.maxMinions += 1;
            player.minionDamage = 1.14f;
            player.minionKB += 5f;
        }
    }
}
