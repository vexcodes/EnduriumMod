using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Terrawrath : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 218;
            item.melee = true;
            item.width = 78;
            item.height = 106;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;

            item.knockBack = 5;
            item.value = 1055000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TerraWrath");
            item.shootSpeed = 24f;
        }
 /*       public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(null, ("TrueWrathOfTheForest"));
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddIngredient(null, ("CoreofCreation"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Wrath");
            Tooltip.SetDefault("'The ultimate blade the heavens brought to this world'");
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = Main.myPlayer;
            float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
            float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
            int num76 = 24;
            int num75 = mod.ProjectileType("TerraWrath");
            int num77 = (int)((float)item.damage * player.meleeDamage);
            int num78 = 2;
            float f = Main.rand.NextFloat() * 6.28318548f;
            float value8 = 200f;
            float value9 = 100f;
            Vector2 vector26 = position + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
            int num2;
            for (int num209 = 0; num209 < 50; num209 = num2 + 3)
            {
                vector26 = position + f.ToRotationVector2() * MathHelper.Lerp(value8, value9, Main.rand.NextFloat());
                if (Collision.CanHit(position, 0, 0, vector26 + (vector26 - position).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
                {
                    break;
                }
                f = Main.rand.NextFloat() * 6.28318548f;
                num2 = num209;
            }
            Vector2 mouseWorld = Main.MouseWorld;
            Vector2 vector27 = mouseWorld - vector26;
            Vector2 vector28 = new Vector2(num82, num83).SafeNormalize(Vector2.UnitY) * num76;
            vector27 = vector27.SafeNormalize(vector28) * num76;
            vector27 = Vector2.Lerp(vector27, vector28, 0.25f);
            Projectile.NewProjectile(vector26, vector27, num75, num77, num78, i, 0f, 0f);
            return true;
        }
    }
}