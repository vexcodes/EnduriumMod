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
    public class CrypticHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;
            item.defense = 5;
            item.value = 100000;
            item.rare = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryptic Arcane Helmet");
            Tooltip.SetDefault("Increases minion damage by 7% and max minions by 1");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("CrypticBody") && legs.type == mod.ItemType("CrypticLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Your minions inflict 'shiver'";
     		((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).MinionShiver = true;

	 }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.07f;
			            player.maxMinions += 1;
        }
				        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CrypticPowerCell"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}