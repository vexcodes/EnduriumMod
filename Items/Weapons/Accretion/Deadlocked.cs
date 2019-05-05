using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace EnduriumMod.Items.Weapons.Accretion
{
	public class Deadlocked : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 127;
            item.crit += 46;
            item.ranged = true;
			item.width = 21;
			item.height = 55;
			item.useTime = 10;
			item.useAnimation = 30;
            item.reuseDelay = 22;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 900000;
			item.rare = 11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AccretionRocket");
			item.shootSpeed = 20f;
            item.useAmmo = 771;
        }

      public override void SetStaticDefaults()
      {
      DisplayName.SetDefault("Deadlocked");
      Tooltip.SetDefault("'Overclocked'\nFires a burst of Accretion bolts and rockets\n50% Chance not to consume rockets.");
      }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccretionBar", 39);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 102, 1f, 0f);
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 60f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            Projectile.NewProjectile(position.X, position.Y, (int)(speedX *= 0.9f), (int)(speedY *= 0.9f), type, damage, knockBack, player.whoAmI);

            Projectile.NewProjectile(position.X, position.Y, (int)(speedX *= 0.6f), (int)(speedY *= 0.6f), type, damage, knockBack, player.whoAmI);
            return true; // return false because we don't want tmodloader to shoot projectile
        }
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() > .5f;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-17, 0);
        }
    }
}
