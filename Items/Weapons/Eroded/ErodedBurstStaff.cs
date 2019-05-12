using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Eroded
{
    public class ErodedBurstStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Staff");
            Tooltip.SetDefault("Fires Eroded Energy\nUpon hitting an enemy the projectile has a chance to split");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 65f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
            float scale = 1f - (Main.rand.NextFloat() * .3f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 26);
            recipe.AddIngredient(null, ("RuneofFear"), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {
            item.damage = 52;
            item.magic = true;
            item.width = 72;
            item.height = 32;
            item.useAnimation = 33;
            item.useTime = 11;
            item.reuseDelay = 24;
            item.UseSound = SoundID.Item43;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            Item.staff[item.type] = true;
            item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            item.rare = 3;
            item.autoReuse = true;
            item.mana = 16;
            item.shoot = mod.ProjectileType("ErodedEnergy");
            item.shootSpeed = 16f;
        }
    }
}