using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class IceClasper : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 32;
            item.noMelee = true;
            item.ranged = true;
            item.width = 24;
            item.height = 54;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 7;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
		        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Clasper");
            Tooltip.SetDefault("Turns arrows into arctic arrows.");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ArcticArrow"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false; //Makes sure to not fire the original projectile
        }
    }
}