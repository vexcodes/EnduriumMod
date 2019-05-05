using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class ThePlaugue : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 120;
            item.melee = true;
            item.width = 56;
            item.height = 78;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ShadeBolt");
            item.shootSpeed = 8f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 37);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Plague");
            Tooltip.SetDefault("Inflitcts 'Shadow touch'\nFires shade bolts\n'Nightmares will take over'");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("ShadowTouch"), 360);

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ViralSlicer", 1);
            recipe.AddIngredient(null, "ShadowFury", 1);
            recipe.AddIngredient(ItemID.BloodButcherer);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddIngredient(null, "TropicalFragment", 2);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ViralSlicer", 1);
            recipe.AddIngredient(null, "ShadowFury", 1);
            recipe.AddIngredient(ItemID.LightsBane);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddIngredient(null, "TropicalFragment", 2);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
