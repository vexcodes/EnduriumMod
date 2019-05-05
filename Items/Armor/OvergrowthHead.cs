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
    public class OvergrowthHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 100000;
            item.rare = 7;
            item.defense = 7; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurian Mask");
            Tooltip.SetDefault("18% increased thrown damage and critical strike chance!");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 23);
            recipe.AddIngredient(null, ("DarkDust"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("OvergrowthChest") && legs.type == mod.ItemType("OvergrowthLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases throwing velocity by 20%\nHitting enemies gives you several different buffs";
            player.thrownVelocity += 0.2f;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Overgrowth = true;

        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.18f;
            player.thrownCrit += 18;
        }
    }
}