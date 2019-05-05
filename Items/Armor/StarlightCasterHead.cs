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
            item.rare = 5;
            item.defense = 8; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight Caster Chainplate");
            Tooltip.SetDefault("");
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
            player.setBonus = "'All magic projectiles are homing with some exceptions'";
            player.AddBuff(mod.BuffType("StarlightOrbit"), 1);
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).StarlightOrbit = true;
        }

        public override void UpdateEquip(Player player)
        {
        }
    }
}
