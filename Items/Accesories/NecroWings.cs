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
    public class NecroWings : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 40;

            item.value = 200000;
            item.rare = 7;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necrotic Wings");
            Tooltip.SetDefault("Allows flight and slow fall");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 100;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1.6f;
            ascentWhenRising = 0.6f;
            maxCanAscendMultiplier = 2.75f;
            maxAscentMultiplier = 1.75f;
            constantAscend = 0.2750f;
        }


        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 4.75f;
            acceleration *= 2.75f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ArcaneWings"));
			            recipe.AddIngredient(null, ("ShadowRemnants"), 25);
			            recipe.AddIngredient(ItemID.SoulofFlight, 30);
						            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
