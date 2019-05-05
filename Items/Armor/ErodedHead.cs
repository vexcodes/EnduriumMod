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
    public class ErodedHead : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;

            item.value = 52000;
            item.rare = 7;
            item.defense = 6; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Helmet");
            Tooltip.SetDefault("Increases thrown crit chance by 9%");
        }
        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("ErodedBody") && legs.type == mod.ItemType("ErodedLegs");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You have a small chance to release an eroded flame upon hitting enemies\nKilling enemies greatly boosts that chance";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).ErodedSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 9;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}