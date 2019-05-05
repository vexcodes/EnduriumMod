using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Dissolution : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dissolution");
            Tooltip.SetDefault("'Turns gel into a mixture of acids'\n95% to not consume gel");
        }

        public override void SetDefaults()
	    {
			item.damage = 162;
			item.ranged = true;
            item.crit += 41;
			item.width = 94;
			item.height = 26;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3f;
			item.UseSound = SoundID.Item20;
			item.value = 900000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AcidPlasma"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 10f;
			item.useAmmo = 23;
		}

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .95f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2; // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4)); // 30 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }
    }
}