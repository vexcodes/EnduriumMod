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
    public class MarbleHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 2;
            item.defense = 2; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rosy Gold Helmet");
            Tooltip.SetDefault("Increases throwing velocity by 4%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("MarbleBody") && legs.type == mod.ItemType("MarbleLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
			player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Dealing damage with throwing items increases throwing item use speed";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).ThrowingSpeedBuff = true;
			player.thrownVelocity += 0.1f;
        }

        public override void UpdateEquip(Player player)
        {
			player.thrownVelocity += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RosyGoldChunk"), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
