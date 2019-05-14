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
    public class BloomlightHeadThrowing : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 20000;
            item.rare = 4;
           item.defense = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Headgear");
            Tooltip.SetDefault("Increases throwing damage by 8%");
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
            player.setBonus = "Increases throwing damage by 5%\nHitting an enemy may boost your throwing damage for a short while.";
            player.thrownDamage += 0.05f;
						((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloomlightThrowing = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.08f;
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
