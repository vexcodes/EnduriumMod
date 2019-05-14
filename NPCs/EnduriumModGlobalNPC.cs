using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.Initializers;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.DataStructures;
using EnduriumMod;

namespace EnduriumMod.NPCs
{
    public class EnduriumModGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public bool BloodFangFlame = false;
        public bool ArmorPenetration1 = false;
        public bool ArmorPenetration2 = false;
        public bool ArmorPenetration3 = false;
        public bool FrostBloodInfection = false;
        public bool Shiver = false;
        public bool GraniteShatter = false;
        public bool AncientCurse = false;
        public bool NatureSting = false;
        public bool whaCK = false;
        public bool RoyalCurse = false;
        public bool AccretionBurn = false;
        public bool HolyGrail = false;
        public bool Voidflame = false;
        public bool NatureReaper = false;
        public bool Purge = false;
        public bool ImperialInferno = false;
        public bool ShadowTouch = false;
        public override void ResetEffects(NPC npc)
        {
            BloodFangFlame = false;
            ArmorPenetration1 = false;
            ShadowTouch = false;
            ArmorPenetration2 = false;
            Purge = false;
            ImperialInferno = false;
            AccretionBurn = false;
            ArmorPenetration3 = false;
            RoyalCurse = false;
            Shiver = false;
            NatureReaper = false;
            whaCK = false;
            Voidflame = false;
            GraniteShatter = false;
            HolyGrail = false;
            NatureSting = false;
            FrostBloodInfection = false;
        }
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            Mod mod = ModLoader.GetMod("EnduriumMod");
            bool AAAA = EnduriumWorld.EndurianLegion;
            if (AAAA)
            {
                pool.Remove(0);
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == 228)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Herbs.PutridGel>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.PutridSpore>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accesories.ErodedPrism>());
                nextSlot++;
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (BloodFangFlame)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 8)
                {
                    damage = 8;
                }
            }
            if (AccretionBurn)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 125;
                if (damage < 25)
                {
                    damage = 25;
                }
            }
            if (ShadowTouch)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 20;
                if (damage < 8)
                {
                    damage = 8;
                }
            }
            if (NatureReaper || ImperialInferno)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 32;
                if (damage < 8)
                {
                    damage = 8;
                }
            }
            if (GraniteShatter)
            {
                npc.defense -= 10;
            }
            if (RoyalCurse)
            {
                npc.defense -= 20;
            }
            if (Shiver)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                if (damage < 4)
                {
                    damage = 4;
                }
                npc.lifeRegen -= 48;
            }
            if (FrostBloodInfection)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 258;
            }
            if (AncientCurse)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 12;
            }
            if (NatureSting)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 18;
            }
            if (whaCK)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                if (damage < 4)
                {
                    damage = 4;
                }
                npc.lifeRegen -= 30;
            }
            if (Voidflame)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 24;
            }
            if (Purge)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 24;
            }
        }
        public static int NatureWarMage = -1;

        public static int FluxQueen = -1;

        public static bool MoonAssery = false;

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == mod.NPCType("NatureWarMage"))
            {
                EnduriumWorld.downedNatureWarMage = true;
            }
            if (npc.type == mod.NPCType("FluxQueen"))
            {
                EnduriumWorld.downedFluxQueen = true;
            }
            if (npc.type == mod.NPCType("ThePrismArcanum") && !EnduriumWorld.downedPrismArcanum)
            {
                Main.NewText("The ground shakes, a powerful tropical energy appears", 66, 244, 194);
                EnduriumWorld.downedPrismArcanum = true;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (BloodFangFlame)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 90, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (Purge)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 173, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (Shiver)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 132, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (AccretionBurn)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(4f, 4f), npc.width + 4, npc.height + 4, 90, npc.velocity.X * 0.4f, npc.velocity.Y * 2.2f, 100, default(Color), 1.8f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.2f;
                    Main.dust[dust].velocity.Y += 0.5f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
            }
            if (NatureReaper)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 89, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (ImperialInferno)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (HolyGrail)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 269, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (whaCK)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 184, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (ShadowTouch)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 37, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (GraniteShatter)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 56, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (RoyalCurse)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 91, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (AncientCurse)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 34, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (Voidflame)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 70, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (FrostBloodInfection)
            {
                if (Main.rand.Next(3) < 2)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 33, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y += 0.25f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
        }
        public int Raycast(int x, int y)
        {
            if (x < 2 || x > Main.maxTilesX - 2)
            {
                ErrorLogger.Log("X is dead.");
                return 0;
            }
            if (y < 2 || y > Main.maxTilesY - 2)
            {
                ErrorLogger.Log("Y is not alive");
                return 0;
            }
            while (!Main.tile[x, y].active())
            {
                y++;
            }
            return y;
        }
        public void SmoothTileRunner(Point position, int size, int type)
        {
            for (int x = position.X - size; x <= position.X + size; x++)
            {
                for (int y = position.Y - size; y <= position.Y + size; y++)
                {
                    if (Vector2.Distance(new Vector2(position.X, position.Y), new Vector2(x, y)) <= size && Main.tile[x, y] != null)
                    {
                        WorldGen.KillTile(x, y, false, false, true);
                        WorldGen.PlaceTile(x, y, (ushort)type, true, true);
                    }
                }
            }
        }
    }
}