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
    public class BoneHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 2;
            item.defense = 3; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Helmet");
            Tooltip.SetDefault("Increases melee critical strike chance and speed by 8%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("BoneBody") && legs.type == mod.ItemType("BoneLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases damage resistance by 10%";
					            player.endurance += 0.05f;
        }

        public override void UpdateEquip(Player player)
        {
                        player.meleeCrit += 8;
			player.meleeSpeed += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BoneScrap"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
