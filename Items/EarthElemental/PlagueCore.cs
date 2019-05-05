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
            Tooltip.SetDefault("Attacks inflict Reaper Nature\nCritical strikes imbue you with spirit energy\nIncreases critical strike chance by 10%\nSummons two earthen crystals to protect you");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 10;
            player.AddBuff(mod.BuffType("EarthTurret"), 1);
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BiologicalCrit = true;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).EarthTurret = true;
        }
    }
}