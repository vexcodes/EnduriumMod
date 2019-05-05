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
    public class AncientHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;
            item.defense = 2;
            item.value = 40000;
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Helmet");
            Tooltip.SetDefault("Increases summon damage by 4%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("AncientBody") && legs.type == mod.ItemType("AncientLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Your minions cause the enemy to become cursed by the spirits of the desert.";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).AncientCurse = true;

        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.04f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AncientMandible"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}