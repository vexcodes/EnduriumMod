using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.HollowWarlock
{
    public class TheNightfall : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 75;
            item.ranged = true;
            item.width = 24;
            item.height = 54;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.value = 1025000;
            item.rare = 9;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 19; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 50f;
            item.useAmmo = 40;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Nightfall");
            Tooltip.SetDefault("Fires rapid bolts of energy");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int gay = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FrostSparkle"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            Main.projectile[gay].extraUpdates = 2;
            Main.projectile[gay].melee = true;
            Main.projectile[gay].magic = false;
            return true; //Makes sure to not fire the original projectile
        }
    }
}