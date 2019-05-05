using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class HellfireRepeater : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 58;
            item.ranged = true;
            item.width = 52;
            item.height = 20;
            item.useTime = 39;

            item.useAnimation = 39;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.value = 25000;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 19; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 18f;
            item.useAmmo = 40;
        }
					    public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Repeater");
            Tooltip.SetDefault("");
        }
		        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.HellfireArrow, damage, knockBack, player.whoAmI, 1.25f, 1.25f); //This is spawning a projectile of type FrostburnArrow using the original stats
         
				return false;
	   }
	           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FieryTissue"), 15);
						            recipe.AddIngredient(null, ("DuskSteel"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
