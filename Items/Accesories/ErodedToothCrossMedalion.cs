using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using EnduriumMod.NPCs;
namespace EnduriumMod.Items.Accesories
{
    public class ErodedToothCrossMedalion : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 30;
            item.height = 32;
            item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            item.rare = 5;
            item.accessory = true;
            item.defense = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Crystal Emblem");
            Tooltip.SetDefault("Hitting enemies occasionally gives you the Blood Blessing buff\nIncreases armor penetration by 12\nIncreases damage slightly\nIncreases life regeneration");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
				player.meleeDamage *= 1.05f;
    	    player.thrownDamage *= 1.05f;
						            player.lifeRegen += 2;
    	    player.rangedDamage *= 1.05f;
    	    player.magicDamage *= 1.05f;
    	    player.minionDamage *= 1.05f;
            player.armorPenetration += 12;
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).BloodFang = true;
        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedToothNecklace"));
            recipe.AddIngredient(null, ("PrismShard"), 10);
			            recipe.AddIngredient(null, ("IceEnergy"), 4);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
