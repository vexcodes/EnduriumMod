using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.TheScourge
{ 
    public class JungleCrown : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 26;
            item.height = 50;
            item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            item.rare = -12;
            item.accessory = true;
            item.defense = 5;
            item.expert = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Thorned Crown");
            Tooltip.SetDefault("Increases all stats\nReleases toxic energy upon taking damage");
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.immune)
            {
                if (Main.rand.Next(12) == 0)
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
                        int num17 = Projectile.NewProjectile(x, y, num13, num14, mod.ProjectileType("ToxicSporeFall"), 50, 5f, player.whoAmI, 0f, 0f);
                        Main.projectile[num17].ai[1] = player.position.Y;
                        Main.projectile[num17].hostile = false;
                        Main.projectile[num17].friendly = true;
                    }
                }
            }
            player.moveSpeed += 0.3f;
            player.manaCost *= 0.9f;
            player.minionDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.thrownDamage += 0.1f;
            player.accRunSpeed += 1f;
        }


    }
}

