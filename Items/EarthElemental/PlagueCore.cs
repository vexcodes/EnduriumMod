using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EarthElemental
{
    public class PlagueCore : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 34;
            item.height = 42;
            item.value = Terraria.Item.buyPrice(0, 15, 50, 0);
            item.rare = -12;
            item.expert = true;
            item.accessory = true;
            item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Scale");
            Tooltip.SetDefault("Attacks inflict Reaper Nature\nCritically striking an enemy increases damage for a short time\nIncreases critical strike chance by 5%\nSummons two earthen crystals to protect you");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 5;
            player.AddBuff(mod.BuffType("EarthTurret"), 1);
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BiologicalCrit = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).EarthTurret = true;
        }
    }
}