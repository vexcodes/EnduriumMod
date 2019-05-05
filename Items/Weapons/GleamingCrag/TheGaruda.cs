using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.GleamingCrag
{
    public class TheGaruda : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 72;
            item.ranged = true;
            item.width = 30;
            item.height = 62;
            item.useTime = 25;

            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.value = 125000;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 19; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 20f;
            item.useAmmo = 40;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Garuda");
            Tooltip.SetDefault("Fires either holy arrows or jester arrows");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 91, damage, knockBack, player.whoAmI, 1.25f, 1.25f); //This is spawning a projectile of type FrostburnArrow using the original stats
                return false; //Makes sure to not fire the original projectile
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 5, damage, knockBack, player.whoAmI, 1.25f, 1.25f); //This is spawning a projectile of type FrostburnArrow using the original stats
            }
            return false;
        }
    }
}
