using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class TalismanofProphecies : ModItem
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
            DisplayName.SetDefault("Talisman of Prophecies");
            Tooltip.SetDefault("'Your mind is sealed within'\nIncreases minion damage by 16% and minion slots by 1\nBoosts your max health by 40");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("EmberNectarFruit"));
            recipe.AddIngredient(null, ("EnchantersRelic"));
            recipe.AddIngredient(null, ("SummonTab"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 40;
            player.maxMinions += 1;
            player.minionDamage *= 1.16f;
        }
    }
}
