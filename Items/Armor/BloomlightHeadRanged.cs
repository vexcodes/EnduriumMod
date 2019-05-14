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
    public class BloomlightHeadRanged : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 20000;
            item.rare = 4;
           item.defense = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Helmet");
            Tooltip.SetDefault("Increases ranged damage by 8%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("BloomlightBody") && legs.type == mod.ItemType("BloomlightLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases ranged damage by 5%\nHitting an enemy may boost your ranged damage for a short while.";
            player.rangedDamage += 0.05f;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloomlightRanged = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 19);
			            recipe.AddIngredient(null, ("NatureEssence"), 4);
						            recipe.AddIngredient(null, ("PutridSpore"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
