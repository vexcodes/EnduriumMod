using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class EmberNectarFruit : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            item.rare = 2;
            item.accessory = true;
            item.defense = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Nectar Fruit");
            Tooltip.SetDefault("Increases max health by 50\nIncreases your max amount of minions and their damage.\n'Sweet'");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 50;
			player.maxMinions += 1;
			            player.minionDamage += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, ("EmberCactusFruit"));
			recipe.AddIngredient(null, ("GoldenAmber"));
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddIngredient(ItemID.BottledHoney, 5);
            recipe.AddIngredient(ItemID.HoneyBlock, 15);
            recipe.AddTile(null, "GraniteAltar");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
