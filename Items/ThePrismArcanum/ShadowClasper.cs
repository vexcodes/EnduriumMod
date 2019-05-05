using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace EnduriumMod.Items.ThePrismArcanum
{
    public class ShadowClasper : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 46;
            item.noMelee = true;
            item.ranged = true;
            item.width = 30;
            item.height = 78;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 7;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 9f;

        }
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("IceClasper"));
            recipe.AddIngredient(null, ("ShadowRemnants"), 20);
            recipe.AddIngredient(null, ("DuskSteel"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Clasper");
            Tooltip.SetDefault("Turns arrows into dust arrows that gain speed overtime");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ShadowArrow"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false; //Makes sure to not fire the original projectile
        }
    }
}