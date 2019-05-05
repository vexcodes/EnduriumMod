using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace EnduriumMod.Items.Weapons.Permarine
{
	public class P95 : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 26;
            item.crit += 10;
            item.ranged = true;
			item.width = 68;
			item.height = 26;
			item.useTime = 2;
			item.useAnimation = 2;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 192405;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 21f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("P95");
            Tooltip.SetDefault("'Technology at it's finest'");
        }   
		
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() > .6f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, (int)(speedX *= 1f), (int)(speedY *= 1f), mod.ProjectileType("P95"), damage, knockBack, player.whoAmI);
            }
            return true; // return false because we don't want tmodloader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-17, 2);
        }
    }
}
