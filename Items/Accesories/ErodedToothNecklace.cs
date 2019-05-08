using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class ErodedToothNecklace : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            item.rare = 4;
            item.accessory = true;
            item.defense = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Tooth Necklace");
            Tooltip.SetDefault("Hitting enemies occasionally gives you the Blood Blessing buff\nIncreases armor penetration by 8\nDecreases damage by 5%\nIncreases life regeneration");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage *= 0.95f;
            player.thrownDamage *= 0.95f;
            player.lifeRegen = +2;
            player.rangedDamage *= 0.95f;
            player.magicDamage *= 0.95f;
            player.minionDamage *= 0.95f;
            player.armorPenetration += 8;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloodFang = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SharkToothNecklace);
            recipe.AddIngredient(null, ("BloodMagnumMedalion"));
            recipe.AddIngredient(null, ("ErodedPrism"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}