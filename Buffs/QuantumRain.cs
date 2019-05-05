using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class QuantumRain : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Quantum Kunai Rain");
            Description.SetDefault("Kunai is falling from the sky");
        }
        public override void Update(Player player, ref int buffIndex)
        {
		if (Main.rand.Next(7) == 0)
			{
								for (int n = 0; n < 6; n++)
						{
							float x = player.position.X + (float)Main.rand.Next(-1000, 1000);
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
							int num17 = Projectile.NewProjectile(x, y, num13, num14, mod.ProjectileType("QuantumKunai"), 80, 5f, player.whoAmI, 0f, 0f);
							Main.projectile[num17].ai[1] = player.position.Y;
							Main.projectile[num17].friendly = true;
													Main.projectile[num17].hostile = false;
						}
						}
        }
    }
}