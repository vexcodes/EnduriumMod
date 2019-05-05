using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.RuneShard
{
    class TheOathblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Oathblade");
            Tooltip.SetDefault("Creates a fearless inferno upon hitting enemies");
        }

        public override void SetDefaults()
        {
            item.knockBack = 4;
            item.melee = true;
            item.useStyle = 1;
            item.crit += 12;
            item.damage = 51;
            item.autoReuse = true;
            item.width = 50;
            item.height = 50;
            item.maxStack = 1;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 32;
            item.useTime = 32;
            item.value = 59500;
            item.rare = 6;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RuneofFear"), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(3, (int)target.position.X, (int)target.position.Y, 1, 1f, 0f);
            Projectile.NewProjectile(target.position.X + target.width / 2, target.position.Y + target.height / 2, 0f, 0f, mod.ProjectileType("FearlessInferno"), (int)(item.damage * player.meleeDamage), item.knockBack, Main.myPlayer, 0f, 0f);
        }
    }
}