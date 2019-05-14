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
    public class StarlightCasterHead : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 40000;
            item.rare = 6;
            item.defense = 8; //42
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GleamingCrag"), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Caster Chainplate");
            Tooltip.SetDefault("Increases magic critical strike chance");
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("StarlightCasterBody") && legs.type == mod.ItemType("StarlightCasterLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "'Most magic projectiles home in on enemies'";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).StarlightOrbit = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 12;
        }
    }
}
