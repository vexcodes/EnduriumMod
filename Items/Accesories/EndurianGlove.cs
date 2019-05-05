using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class EndurianGlove : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 24;
            item.height = 28;
            item.value = Terraria.Item.buyPrice(0, 10, 50, 0);
            item.rare = 8;
            item.accessory = true;
            item.defense = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurian Glove");
              Tooltip.SetDefault("Increases throwing velocity by 35%");
      }

	  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 25);
						            recipe.AddIngredient(null, ("DarkDust"), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownVelocity += 0.35f;
        }
    }
}
