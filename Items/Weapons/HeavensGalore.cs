using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class HeavensGalore : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 100;
            item.melee = true;
            item.width = 58;
            item.height = 58;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;

            item.knockBack = 5;
            item.value = 105500;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HeavensGalore");
            item.shootSpeed = 24f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavens Galore");
            Tooltip.SetDefault("'Wielded by angels, now in your hand\nShoots a bolt of energy");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Excalibur);
            //recipe.AddIngredient(null, ("GrailKatana"));
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddIngredient(null, ("GemofHollow"), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = Main.myPlayer;
            float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
            float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
            int num76 = 24;
            int num75 = mod.ProjectileType("HeavenVoltage");
            int num77 = (int)((float)item.damage * player.meleeDamage);
            int num78 = 2;
            float f = Main.rand.NextFloat() * 6.28318548f;
            float value8 = 60f;
            float value9 = 20f;
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

            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("HeavensGalore"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false;
        }
    }
}