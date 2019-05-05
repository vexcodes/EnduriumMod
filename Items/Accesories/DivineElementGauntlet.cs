using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    public class DivineElementGauntlet : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 15, 50, 0);
            item.rare = 8;
            item.accessory = true;
            item.defense = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Element Gauntlet");
            Tooltip.SetDefault("Hitting Enemies may bless you with several buffs, and spawn a spirit that will explode and heal you\nYour movement speed, damage, live regen, defense and critical strike chance depend on the amount of health you currently have\nStars fall from heavens when you take damage\nInvincibility lasts longer\nStanding still regenrates live quicker\nYou take 20% less damage\nIncreases max health by 100\nIncreases damage done by 15%");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
                player.pStone = true;
                player.longInvince = true;
                player.starCloak = true;
                player.shinyStone = true;
            player.rangedDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.thrownDamage += 0.15f;
            if (player.statLife <= (player.statLifeMax2 * 0.75f))
            {
                player.rangedDamage += 0.19f;
                player.meleeDamage += 0.19f;
                player.magicDamage += 0.19f;
                player.thrownDamage += 0.19f;
            }
            if (player.statLife <= (player.statLifeMax2 * 0.55f))
            {
                player.moveSpeed += 0.55f;
            }
            if (player.statLife <= (player.statLifeMax2 * 0.50f))
            {
                player.meleeCrit += 15;
                player.thrownCrit += 15;
                player.rangedCrit += 15;
                player.magicCrit += 15;
            }
            if (player.statLife >= (player.statLifeMax2 * 0.95f))
            {
                player.lifeRegen = 9;
            }
            player.statLifeMax2 += 100;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloodFang = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Lightning = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).HealingSpirit = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BlessedEmblem"));
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
