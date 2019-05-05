using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;
namespace EnduriumMod.Items.Accesories
{
    public class ParadoxEmblem : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(2, 50, 0, 0);
            item.rare = 10;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paradox Emblem");
            Tooltip.SetDefault("Hitting enemies occasionally gives you the Blood Blessing buff\nIncreases armor penetration by 25\nIncreases damage by 10%\nIncreases life regeneration and max health\nIncreases movement speed\nGetting hit might boost your speed and life regeneration for a short amount of time\nDuring that time you will dodge any attack\nCritical strikes deal tripple damage");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TheCrossofLifeshift"));
            recipe.AddIngredient(null, ("ErodedToothCrossMedalion"));
            recipe.AddIngredient(null, ("ChaosCross"));
            recipe.AddIngredient(null, ("StarShard"), 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage *= 1.1f;
            player.thrownDamage *= 1.1f;
            player.statLifeMax2 += 50;
            player.lifeRegen = +3;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).SwiftEmblemV2 = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).ChaosCrit = true;
            player.rangedDamage *= 1.1f;
            player.magicDamage *= 1.1f;
            player.minionDamage *= 1.1f;
            player.armorPenetration += 25;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloodFang = true;
        }
    }
}