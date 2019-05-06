using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class BloodStainedMedalion : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 32;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Stained Medalion");
            Tooltip.SetDefault("Increases damage resistance and max health by 15%\nMay confuse nearby enemies after getting struck\nWill inflict ichor to nearby enemies after getting struck\nIncreases life regeneration");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("EyeofFlesh"));
            recipe.AddIngredient(ItemID.BrainOfConfusion);
            recipe.AddIngredient(null, ("ErodedPrism"), 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 15);
            recipe.AddIngredient(ItemID.TissueSample, 45);
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = (int)((float)player.statLifeMax2 * 1.15f);
            player.brainOfConfusion = true;
            player.lifeRegen += 2;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloodMedalion = true;
            player.endurance += 0.15f;
        }
    }
}