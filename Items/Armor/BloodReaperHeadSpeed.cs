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
    public class BloodReaperHeadSpeed : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 2;
            item.defense = 1; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Fang Mask");
            Tooltip.SetDefault("Increases movement speed by 5%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("BloodReaperBody") && legs.type == mod.ItemType("BloodReaperLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
			player.armorEffectDrawShadow = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases movement speed by 5%\nGrants running abilities";
            player.moveSpeed += 0.05f;
            player.accRunSpeed += 2.2f;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodFangCore"), 22);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
