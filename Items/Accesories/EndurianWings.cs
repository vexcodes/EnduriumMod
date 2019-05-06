using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.Wings)]
    public class EndurianWings : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 40;

            item.value = 1000000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurian Wings");
            Tooltip.SetDefault("Allows flight and slow fall");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 200;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.1f;
            ascentWhenRising = 1f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 2f;
            constantAscend = 0.2f;
        }


        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 7.5f;
            acceleration *= 16f;
        }
        public override bool WingUpdate(Player player, bool inUse)
        {
            if (inUse)
            {
                Dust.NewDust(player.position, player.width, player.height, 89, 0, 0, 0, Color.Green, 0.95f);
                base.WingUpdate(player, inUse);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 35);
            recipe.AddIngredient(null, ("DarkDust"), 20);
            recipe.AddIngredient(null, ("TropicalFeather"), 2);
            recipe.AddIngredient(ItemID.SoulofFlight, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}