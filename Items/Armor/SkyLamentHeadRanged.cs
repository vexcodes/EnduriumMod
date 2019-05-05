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
    public class SkyLamentHeadRanged : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 2;
            item.defense = 2; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Lament Headgear");
            Tooltip.SetDefault("Increases ranged damage by 8%");
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
            player.setBonus = "Increases ranged damage by 10%";
            player.rangedDamage += 0.10f;
            
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("SkyGlazeAlloy"), 15);
            recipe.AddTile(null, "SkyLamentAnvil");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
