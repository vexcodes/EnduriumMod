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
    public class EmberFlareHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 6;
            item.defense = 8; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Flare Helmet");
            Tooltip.SetDefault("Increases magic critical strike chance by 10%");
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FieryTissue"), 16);
			            recipe.AddIngredient(null, ("DuskSteel"), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("EmberFlareBody") && legs.type == mod.ItemType("EmberFlareLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "The fire magic fills you with anger, you deal 25% more magic damage at a higher mana cost";
                player.magicDamage += 0.25f;
						            player.manaCost *= 1.15f;
	}

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 10;
        }
    }
}
