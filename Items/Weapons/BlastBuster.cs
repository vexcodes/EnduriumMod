using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Weapons
{
    public class BlastBuster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blast Buster");
            Tooltip.SetDefault("Fires flaming blasts that can quickly hit an enemy 2 times");
        }
        public override void SetDefaults()
        {

            item.damage = 30;
            item.magic = true;
            item.mana = 20;
            item.width = 52;
            item.height = 22;
            item.useTime = 56;
            item.useAnimation = 56;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4.25f;
            item.value = 30000;
            item.rare = 5;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BlastBuster");
            item.shootSpeed = 12f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("MagmaCore"), 12);
            recipe.AddIngredient(null, ("AncientMandible"), 11);
            recipe.AddIngredient(null, ("BloodEnergy"), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}