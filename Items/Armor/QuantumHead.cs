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
    public class QuantumHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 100000;
            item.rare = 7;
            item.defense = 19; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quantum Helmet");
            Tooltip.SetDefault("Increases throwing velocity by 20%");
        }
        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("QuantumBody") && legs.type == mod.ItemType("QuantumLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Getting hit causes quantum kunai to rain from the sky!";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).QuantumRain = true;

        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.2f;
        }
    }
}
