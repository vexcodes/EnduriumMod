using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Permarine
{
    class Catalyze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Catalyze");
            Tooltip.SetDefault("Releases shadowflames upon hitting enemies");
        }

        public override void SetDefaults()
        {
            item.knockBack = 4;
            item.melee = true;
            item.useStyle = 1;
            item.crit += 32;
            item.damage = 220;
            item.autoReuse = true;
            item.width = 50;
            item.height = 50;
            item.maxStack = 1;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 18;
            item.useTime = 18;
            item.value = 79500;
            item.rare = 11;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {

            Main.PlaySound(3, (int)target.position.X, (int)target.position.Y, 1, 1f, 0f);
            int num3;
            int num626 = 4;
            if (Main.rand.Next(2) == 0)
            {
                num3 = num626;
                num626 = num3 + 2;
            }
            if (Main.rand.Next(2) == 0)
            {
                num3 = num626;
                num626 = num3 + 2;
            }
            if (Main.rand.Next(2) == 0)
            {
                num3 = num626;
                num626 = num3 + 2;
            }
            for (int num627 = 0; num627 < num626; num627 = num3 + 1)
            {
                float num628 = (float)Main.rand.Next(-35, 36) * 0.02f;
                float num629 = (float)Main.rand.Next(-35, 36) * 0.02f;
                num628 *= 10f;
                num629 *= 10f;
                Projectile.NewProjectile(target.position.X + target.width, target.position.Y + target.width, num628, num629, mod.ProjectileType("Catalyze"), (int)(item.damage * player.meleeDamage), item.knockBack, Main.myPlayer, 0f, 0f);
                num3 = num627;
            }
        }
    }
}