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
    public class BloomlightHeadMagic : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 20000;
            item.rare = 4;
           item.defense = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomlight Mask");
            Tooltip.SetDefault("Decreases mana ussage by 10%");
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
            player.setBonus = "Increases magic damage by 10% and max mana by 50\nHitting an enemy may boost your magic damage for a short while.";
            player.magicDamage += 0.1f;
			player.statManaMax2 += 50;
									((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloomlightMagic = true;
        }

        public override void UpdateEquip(Player player)
        {
		            player.manaCost *= 0.90f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloomlightBar"), 19);
			            recipe.AddIngredient(null, ("NatureEssence"), 4);
						            recipe.AddIngredient(null, ("PutridSpore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
