using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.TheReborn
{
    public class TheLeechingDaggers : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 110;
            item.melee = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 8;
            item.crit = 10;
            item.useAnimation = 8;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = Terraria.Item.buyPrice(1, 0, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LeechingDagger");
            item.shootSpeed = 18f;
            item.useTurn = true;
            item.consumable = false;
            item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(null, ("CoreofRebirth"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leeching Blood Daggers");
            Tooltip.SetDefault("Throws a barrage of bouncing life stealing daggers");
        }
		        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                            int numberProjectiles = 2 + Main.rand.Next(4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(45));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("LeechingDagger"), damage, knockBack, player.whoAmI);
            }
			       return false;
	   }
    }
}
