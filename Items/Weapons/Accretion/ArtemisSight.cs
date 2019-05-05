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
	public class ArtemisSight : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 180;
            item.crit += 46;
            item.ranged = true;
			item.width = 36;
			item.height = 94;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
            item.UseSound = SoundID.Item5;
			item.value = 900000;
			item.rare = 11;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("AccretionArrow");
			item.shootSpeed = 20f;
            item.useAmmo = 40;
        }

      public override void SetStaticDefaults()
      {
          DisplayName.SetDefault("Artemis Sight");
      Tooltip.SetDefault("'Neva Miss'\nTurns arrows into Accertion Arrows");
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
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X *= 0.7f), (int)(perturbedSpeed.Y *= 0.7f), mod.ProjectileType("AccretionArrow"), damage, knockBack, player.whoAmI);
            return true; // return false because we don't want tmodloader to shoot projectile
        }
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() > .25f;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-11, 0);
        }
    }
}
