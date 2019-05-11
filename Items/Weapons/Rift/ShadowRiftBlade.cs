using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Rift
{
    public class ShadowRiftBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 150;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("VoidBlade");
            item.shootSpeed = 22f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Fate");
            Tooltip.SetDefault("Fires a burst of shortlived projectiles\nHitting enemies with the sword creates shadowflame");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5; // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X *= 1.25f, perturbedSpeed.Y *= 1.25f, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
            Main.PlaySound(3, (int)target.position.X, (int)target.position.Y, 1, 1f, 0f);
            Projectile.NewProjectile(target.position.X + target.width / 2, target.position.Y + target.height / 2, 0f, 0f, mod.ProjectileType("FearlessInferno"), (int)(item.damage * player.meleeDamage), item.knockBack, Main.myPlayer, 0f, 0f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RiftShard"), 21);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
