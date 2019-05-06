using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheGatekeeper
{
    public class EmperorsAward : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 26;
            item.height = 50;
            item.value = Terraria.Item.buyPrice(1, 50, 0, 0);
            item.rare = -12;
            item.accessory = true;
            item.defense = 5;
            item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emperor's Award");
            Tooltip.SetDefault("'You completed his challenge'\nIncreases damage by 10% when below 50% health\nIncreases critical strike chance by 8% when below 75% health\nIncreases damage resistance by 12% when below 40% health\nSlowly regenerates life\nFlames rain from hell when struck");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen = +2;
            if (player.statLife <= (player.statLifeMax2 * 0.50f))
            {
                player.meleeDamage *= 1.1f;
                player.thrownDamage *= 1.1f;
                player.rangedDamage *= 1.1f;
                player.magicDamage *= 1.1f;
                player.minionDamage *= 1.1f;
            }
            if (player.statLife <= (player.statLifeMax2 * 0.40f))
            {
                player.endurance += 0.12f;
            }
            if (player.statLife <= (player.statLifeMax2 * 0.75f))
            {
                player.magicCrit += 8;
                player.meleeCrit += 8;
                player.rangedCrit += 8;
                player.thrownCrit += 8;
            }
            if (player.immune)
            {
                if (Main.rand.Next(6) == 0)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        float x = player.position.X + (float)Main.rand.Next(-400, 400);
                        float y = player.position.Y - (float)Main.rand.Next(500, 800);
                        Vector2 vector = new Vector2(x, y);
                        float num13 = player.position.X + (float)(player.width / 2) - vector.X;
                        float num14 = player.position.Y + (float)(player.height / 2) - vector.Y;
                        num13 += (float)Main.rand.Next(-100, 101);
                        int num15 = 23;
                        float num16 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
                        num16 = (float)num15 / num16;
                        num13 *= num16;
                        num14 *= num16;
                        int num17 = Projectile.NewProjectile(x, y, num13, num14, 326, 60, 5f, player.whoAmI, 0f, 0f);
                        Main.projectile[num17].ai[1] = player.position.Y;
                        Main.projectile[num17].hostile = false;
                        Main.projectile[num17].friendly = true;
                    }
                }
                if (Main.rand.Next(4) == 0)
                {
                    int num11 = Main.rand.Next(1, 3);
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector += player.velocity * 3f;
                        vector.Normalize();
                        vector *= (float)Main.rand.Next(35, 39) * 0.1f;
                        int num12 = 100;
                        int num18 = Projectile.NewProjectile(player.Center.X, player.Center.Y, vector.X, vector.Y, 326, num12, 1f, player.whoAmI, 0f, 0f);
                        Main.projectile[num18].hostile = false;
                        Main.projectile[num18].friendly = true;
                    }
                }
            }
        }
    }
}