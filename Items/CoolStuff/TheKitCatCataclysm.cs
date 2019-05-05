using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.CoolStuff
{
    public class TheKitCatCataclysm : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 150;
            item.melee = true;
            item.width = 70;
            item.height = 78;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 2135000;
            item.rare = -12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CatAclysm");
            item.shootSpeed = 19f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cat Cataclysm");
            Tooltip.SetDefault("'Fused with power of the astral gods'\nCreates a cat-aclysm of planet energy");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}