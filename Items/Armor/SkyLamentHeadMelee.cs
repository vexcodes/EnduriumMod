using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SkyLamentHeadMelee : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 20000;
            item.rare = 4;
            item.defense = 6; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Lament Helmet");
            Tooltip.SetDefault("Increases melee critical strike chance by 8%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("SkyLamentBody") && legs.type == mod.ItemType("SkyLamentLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases damage by 12%";
            player.meleeDamage += 0.12f;
          
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 12);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
