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
    public class EtherHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 20000;
            item.rare = 5;
           item.defense = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ether Vissage");
            Tooltip.SetDefault("Increases summon damage by 14%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("EtherBody") && legs.type == mod.ItemType("EtherLegs");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Getting hit releases ether parasites from your armor";
									((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).EtherArmorBonus = true;
        }

        public override void UpdateEquip(Player player)
        {
			            player.minionDamage += 0.14f;
        }
	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FrigidFragment"), 13);
			            recipe.AddIngredient(null, ("DuskSteel"), 22);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
