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
    public class BloodReaperHeadThrowing : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 2;
           
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Fang Headgear");
            Tooltip.SetDefault("Increases throwing damage by 5%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("BloodReaperBody") && legs.type == mod.ItemType("BloodReaperLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases throwing critical strike chance\nGrants increased throwing velocity";
            player.thrownVelocity += 0.13f;
            player.thrownCrit += 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodFangCore"), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
