using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Weapons
{
    public class EruptionBuster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eruption Buster");
            Tooltip.SetDefault("Fires balls of rupturing fire\nHitting enemies creates a small afterblast");
        }
        public override void SetDefaults()
        {

            item.damage = 86;
            item.magic = true;
            item.mana = 16;
            item.width = 68;
            item.height = 28;
            item.useTime = 51;
            item.useAnimation = 51;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4.25f;
            item.value = 230000;
            item.rare = 7;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EruptionBuster");
            item.shootSpeed = 14f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BlastBuster"));
            recipe.AddIngredient(null, ("HolySilver"), 12);
            recipe.AddIngredient(null, ("RoyalCrystal"), 20);
            recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(15, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 60f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}