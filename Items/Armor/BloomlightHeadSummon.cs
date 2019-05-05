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
    public class BloomlightHeadSummon : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 20000;
            item.rare = 4;
           item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Visor");
            Tooltip.SetDefault("Increases minion damage by 15%");
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
            player.setBonus = "Increases max minions";
			            player.maxMinions += 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 19);
			            recipe.AddIngredient(null, ("NatureEssence"), 5);
						            recipe.AddIngredient(null, ("PutridSpore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
