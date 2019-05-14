using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items
{
    public class CrownofSouls : ModItem
    {
        public int StarFall = 0;
        public override void SetDefaults()
        {

            item.width = 62;
            item.height = 62;
            item.useTime = 2;
            item.maxStack = 30;
            item.consumable = false;
            item.useAnimation = 2;
            item.useStyle = 2;
            item.noMelee = true;
            item.value = 1000000;
            item.UseSound = SoundID.Item67;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("MoonPlasm"), 250);
            recipe.AddIngredient(null, ("CoreofCreation"), 10);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unknown Device");
            Tooltip.SetDefault("Causes a world eroding eplosion that spreads a star plaugue over the lands\nMay have negative effects");
        }
        public override bool UseItem(Player player)
        {
            dropMeteor();
            int num3 = 0;
            for (int num997 = 0; num997 < 20; num997 = num3 + 1)
            {
                int num998 = Dust.NewDust(player.position, player.width, player.height, 156, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num998].position = player.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * (float)player.width / 2f;
                Dust dust3 = Main.dust[num998];
                dust3.velocity *= 2.1f;
                Main.dust[num998].noGravity = true;
                Main.dust[num998].fadeIn = 1.5f;

                num3 = num997;
            }
            for (int num999 = 0; num999 < 15; num999 = num3 + 1)
            {
                int num1000 = Dust.NewDust(player.position, player.width, player.height, 156, 0f, 0f, 0, default(Color), 3.7f);
                Main.dust[num1000].position = player.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy((double)player.velocity.ToRotation(), default(Vector2)) * (float)player.width / 2f;
                Main.dust[num1000].noGravity = true;
                Dust dust3 = Main.dust[num1000];
                dust3.velocity *= 1.3f;
                num3 = num999;
            }
            float num1001 = (float)Main.rand.NextDouble() * 6.28318548f;
            float num1002 = (float)Main.rand.NextDouble() * 6.28318548f;
            float num1003 = (float)Main.rand.NextDouble() * 6.28318548f;
            float num1004 = 8f + (float)Main.rand.NextDouble() * 7f;
            float num1005 = 8f + (float)Main.rand.NextDouble() * 7f;
            float num1006 = 8f + (float)Main.rand.NextDouble() * 7f;
            float num1007 = num1004;
            if (num1005 > num1007)
            {
                num1007 = num1005;
            }
            if (num1006 > num1007)
            {
                num1007 = num1006;
            }
            for (int num1008 = 0; num1008 < 200; num1008 = num3 + 1)
            {
                int num1009 = 135;
                float scaleFactor14 = num1007;
                if (num1008 > 50)
                {
                    scaleFactor14 = num1005;
                }
                if (num1008 > 100)
                {
                    scaleFactor14 = num1004;
                }
                if (num1008 > 150)
                {
                    scaleFactor14 = num1006;
                }
                int num1010 = Dust.NewDust(player.position, 156, 156, num1009, 0f, 0f, 156, default(Color), 1f);
                Vector2 vector138 = Main.dust[num1010].velocity;
                Main.dust[num1010].position = player.Center;
                vector138.Normalize();
                vector138 *= scaleFactor14;
                if (num1008 > 150)
                {
                    vector138.Y *= 0.5f;
                    vector138 = vector138.RotatedBy((double)num1003, default(Vector2));
                }
                else if (num1008 > 100)
                {
                    vector138.X *= 0.5f;
                    vector138 = vector138.RotatedBy((double)num1001, default(Vector2));
                }
                else if (num1008 > 50)
                {
                    vector138.Y *= 0.5f;
                    vector138 = vector138.RotatedBy((double)num1002, default(Vector2));
                }
                Dust dust3 = Main.dust[num1010];
                dust3.velocity *= 0.4f;
                dust3 = Main.dust[num1010];
                dust3.velocity += vector138;
                if (num1008 <= 200)
                {
                    Main.dust[num1010].scale = 2f;
                    Main.dust[num1010].noGravity = true;
                    Main.dust[num1010].fadeIn = Main.rand.NextFloat() * 2f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[num1010].fadeIn = 2.5f;
                    }
                    Main.dust[num1010].noLight = true;
                    if (num1008 < 100)
                    {
                        dust3 = Main.dust[num1010];
                        dust3.position += Main.dust[num1010].velocity * 26f;
                        dust3 = Main.dust[num1010];
                        dust3.velocity *= -1f;
                    }
                }
                num3 = num1008;
            }
            return true;
        }
        public static void dropMeteor()
        {
            bool flag = true;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    flag = false;
                    break;
                }
            }
            float num2 = (float)(Main.maxTilesX / 4200);
            int num3 = (int)(600f * num2);
            float num5 = 800;
            while (!flag)
            {
                float num6 = (float)Main.maxTilesX * 0.1f;
                int num7 = Main.rand.Next(170, Main.maxTilesX - 180);
                while ((float)num7 > (float)Main.spawnTileX - num6 && (float)num7 < (float)Main.spawnTileX + num6)
                {
                    num7 = Main.rand.Next(150, Main.maxTilesX - 150);
                }
                int k = (int)(Main.worldSurface * 0.3);
                while (k < Main.maxTilesY)
                {
                    if (Main.tile[num7, k].active() && Main.tileSolid[(int)Main.tile[num7, k].type])
                    {
                        int num8 = 0;
                        int num9 = 15;
                        for (int l = num7 - num9; l < num7 + num9; l++)
                        {
                            for (int m = k - num9; m < k + num9; m++)
                            {
                                if (WorldGen.SolidTile(l, m))
                                {
                                    num8++;
                                    if (Main.tile[l, m].type == 189 || Main.tile[l, m].type == 202)
                                    {
                                        num8 -= 100;
                                    }
                                }
                                else if (Main.tile[l, m].liquid > 0)
                                {
                                    num8--;
                                }
                            }
                        }
                        if ((float)num8 < num5)
                        {
                            num5 -= 0.5f;
                            break;
                        }
                        flag = meteor(num7, k);
                        if (flag)
                        {
                            break;
                        }
                        break;
                    }
                    else
                    {
                        k++;
                    }
                }
                if (num5 < 100f)
                {
                    return;
                }
            }
        }

        public static bool meteor(int i, int j)
        {

            Mod mod = ModLoader.GetMod("EnduriumMod");
            if (i < 100 || i > Main.maxTilesX - 100)
            {
                return false;
            }
            if (j < 100 || j > Main.maxTilesY - 100)
            {
                return false;
            }
            int num = 55;
            Rectangle rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);
            for (int k = 0; k < 255; k++)
            {
                if (Main.player[k].active)
                {
                    Rectangle value = new Rectangle((int)(Main.player[k].position.X + (float)(Main.player[k].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[k].position.Y + (float)(Main.player[k].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
                    if (rectangle.Intersects(value))
                    {
                        return false;
                    }
                }
            }
            for (int l = 0; l < 200; l++)
            {
                if (Main.npc[l].active)
                {
                    Rectangle value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
                    if (rectangle.Intersects(value2))
                    {
                        return false;
                    }
                }
            }
            for (int m = i - num; m < i + num; m++)
            {
                for (int n = j - num; n < j + num; n++)
                {
                    if (Main.tile[m, n].active() && TileID.Sets.BasicChest[(int)Main.tile[m, n].type])
                    {
                        return false;
                    }
                }
            }
            num = WorldGen.genRand.Next(27, 39);
            for (int num2 = i - num; num2 < i + num; num2++)
            {
                for (int num3 = j - num; num3 < j + num; num3++)
                {
                    if (num3 > j + Main.rand.Next(-2, 3) - 5)
                    {
                        float num4 = (float)Math.Abs(i - num2);
                        float num5 = (float)Math.Abs(j - num3);
                        float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                        if ((double)num6 < (double)num * 0.9 + (double)Main.rand.Next(-4, 5))
                        {
                            if (!Main.tileSolid[(int)Main.tile[num2, num3].type])
                            {
                                Main.tile[num2, num3].active(false);
                            }
                            Main.tile[num2, num3].type = (ushort)mod.TileType("PlanetarShard");
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(8, 18);
            for (int num7 = i - num; num7 < i + num; num7++)
            {
                for (int num8 = j - num; num8 < j + num; num8++)
                {
                    if (num8 > j + Main.rand.Next(-2, 3) - 4)
                    {
                        float num9 = (float)Math.Abs(i - num7);
                        float num10 = (float)Math.Abs(j - num8);
                        float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                        if ((double)num11 < (double)num * 0.8 + (double)Main.rand.Next(-3, 4))
                        {
                            Main.tile[num7, num8].active(false);
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(18, 28);
            for (int num12 = i - num; num12 < i + num; num12++)
            {
                for (int num13 = j - num; num13 < j + num; num13++)
                {
                    float num14 = (float)Math.Abs(i - num12);
                    float num15 = (float)Math.Abs(j - num13);
                    float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                    if ((double)num16 < (double)num * 0.7)
                    {
                        if (Main.tile[num12, num13].type == 5 || Main.tile[num12, num13].type == 32 || Main.tile[num12, num13].type == 352)
                        {
                            WorldGen.KillTile(num12, num13, false, false, false);
                        }
                        Main.tile[num12, num13].liquid = 0;
                    }
                    if (Main.tile[num12, num13].type == (ushort)mod.TileType("PlanetarShard"))
                    {
                        if (!WorldGen.SolidTile(num12 - 1, num13) && !WorldGen.SolidTile(num12 + 1, num13) && !WorldGen.SolidTile(num12, num13 - 1) && !WorldGen.SolidTile(num12, num13 + 1))
                        {
                            Main.tile[num12, num13].active(false);
                        }
                        else if ((Main.tile[num12, num13].halfBrick() || Main.tile[num12 - 1, num13].topSlope()) && !WorldGen.SolidTile(num12, num13 + 1))
                        {
                            Main.tile[num12, num13].active(false);
                        }
                    }
                    WorldGen.SquareTileFrame(num12, num13, true);
                    WorldGen.SquareWallFrame(num12, num13, true);
                }
            }
            num = WorldGen.genRand.Next(13, 22);
            for (int num17 = i - num; num17 < i + num; num17++)
            {
                for (int num18 = j - num; num18 < j + num; num18++)
                {
                    if (num18 > j + WorldGen.genRand.Next(-3, 4) - 3 && Main.tile[num17, num18].active() && Main.rand.Next(10) == 0)
                    {
                        float num19 = (float)Math.Abs(i - num17);
                        float num20 = (float)Math.Abs(j - num18);
                        float num21 = (float)Math.Sqrt((double)(num19 * num19 + num20 * num20));
                        if ((double)num21 < (double)num * 0.8)
                        {
                            if (Main.tile[num17, num18].type == 5 || Main.tile[num17, num18].type == 32 || Main.tile[num17, num18].type == 352)
                            {
                                WorldGen.KillTile(num17, num18, false, false, false);
                            }
                            Main.tile[num17, num18].type = (ushort)mod.TileType("PlanetarShard");
                            WorldGen.SquareTileFrame(num17, num18, true);
                        }
                    }
                }
            }
            num = WorldGen.genRand.Next(30, 38);
            for (int num22 = i - num; num22 < i + num; num22++)
            {
                for (int num23 = j - num; num23 < j + num; num23++)
                {
                    if (num23 > j + WorldGen.genRand.Next(-2, 3) && Main.tile[num22, num23].active() && Main.rand.Next(20) == 0)
                    {
                        float num24 = (float)Math.Abs(i - num22);
                        float num25 = (float)Math.Abs(j - num23);
                        float num26 = (float)Math.Sqrt((double)(num24 * num24 + num25 * num25));
                        if ((double)num26 < (double)num * 0.85)
                        {
                            if (Main.tile[num22, num23].type == 5 || Main.tile[num22, num23].type == 32 || Main.tile[num22, num23].type == 352)
                            {
                                WorldGen.KillTile(num22, num23, false, false, false);
                            }
                            Main.tile[num22, num23].type = (ushort)mod.TileType("PlanetarShard");
                            WorldGen.SquareTileFrame(num22, num23, true);
                        }
                    }
                }
            }
            if (Main.netMode == 0)
            {
                Main.NewText("A planteray strike has struck nearby", 50, 255, 255, false);
            }
            if (Main.netMode != 1)
            {
                NetMessage.SendTileSquare(-1, i, j, 40, TileChangeType.None);
            }
            return true;
        }
    }
}