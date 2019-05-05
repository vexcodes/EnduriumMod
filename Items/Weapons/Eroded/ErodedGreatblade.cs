using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Eroded
{
    public class ErodedGreatblade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 64;
            item.melee = true;
            item.width = 52;
            item.height = 52;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.useTurn = true;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 21);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Greatblade");
            Tooltip.SetDefault("Hitting Enemies causes fire eruptions\nInflicts shadow touch");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("ShadowTouch"), 760);
            {
                for (int num53 = 0; num53 < 25; num53++)
                {
                    Dust dust = Main.dust[Dust.NewDust(target.position + target.velocity * 5f, target.width, target.height, 21, 0f, 0f, 100, Color.Transparent, 2.5f)];
                    dust.noGravity = true;
                    dust.velocity *= 2f;
                    dust.fadeIn = 1.5f;
                }
            }
            int num11 = Main.rand.Next(2, 4);
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-300, 301), (float)Main.rand.Next(-300, 301));
                vector += target.velocity * 12f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.3f;
                int num12 = 52;
                Projectile.NewProjectile(target.Center.X, target.Center.Y, vector.X, vector.Y, mod.ProjectileType("ErodedFire"), damage, 0f, player.whoAmI);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 22);
            recipe.AddIngredient(null, ("RuneofFear"), 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}