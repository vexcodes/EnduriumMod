using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Eroded
{
    public class ErodedBow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 35;
            item.ranged = true;
            item.width = 34;
            item.height = 50;
            item.useTime = 7;

            item.useAnimation = 14;
            item.useStyle = 5;
            item.reuseDelay = 12;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 125000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 19; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 27f;
            item.useAmmo = 40;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 24);
            recipe.AddIngredient(null, ("RuneofFear"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Bow");
            Tooltip.SetDefault("Has a chance to turn arrows into shadowflame arrows");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 495, damage, knockBack, player.whoAmI, 1.25f, 1.25f); //This is spawning a projectile of type FrostburnArrow using the original stats
                return false; //Makes sure to not fire the original projectile
            }
            return true;
        }
    }
}
