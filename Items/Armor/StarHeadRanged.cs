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
    public class StarHeadRanged : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 18;
            item.height = 18;

            item.value = 120000;
            item.rare = 10;
            item.defense = 15; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Headset");
            Tooltip.SetDefault("Increases ranged damage and critical strike chance by 20%");
        }
        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("StarBody") && legs.type == mod.ItemType("StarLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Pressing the 'Star Call' ability button will make all ranged projectiles explode into star shards for 5 seconds";
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).StarSetRanged = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).StarSet = true;
        }

        public override void UpdateEquip(Player player)
        {
			player.rangedDamage += 0.20f;
            player.rangedCrit += 20;
        }
    }
}
