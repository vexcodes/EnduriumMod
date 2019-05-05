using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.KeeperofHollow
{
    public class KeepersBlade : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Keeper's Blade");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 300;
            npc.damage = 124;
            npc.knockBackResist = 0f;
            npc.width = 46;
            npc.height = 46;
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit33;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int num623 = 0; num623 < 2; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
            if (npc.life <= 0)
            {
                for (int num623 = 0; num623 < 6; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
            }
        }
        int num1 = 0;
        int num2 = 50;
        int Spawn = 0;
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (Spawn <= 50)
            {
                return false;
            }
            return true;
        }
        public override void AI()
        {
            Spawn += 1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if (!Main.player[npc.target].dead)
            {
                if (npc.ai[0] == 0f)
                {
                    for (int num623 = 0; num623 < 15; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType("HollowBurn"), 0f, 0f, 100, default(Color), 1f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 4f;
                    }
                    float num313 = 22f; //speed of dashing
                    if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != 1)
                    {
                        num313 = 24f;
                    }
                    if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != 1)
                    {
                        num313 = 26f;
                    }
                    if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != 1)
                    {
                        num313 = 28f;
                    } //dashes faster the less health it has
                    Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num314 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
                    float num315 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
                    float num316 = (float)Math.Sqrt((double)(num314 * num314 + num315 * num315));
                    num316 = num313 / num316;
                    num314 *= num316;
                    num315 *= num316;
                    npc.velocity.X = num314;
                    npc.velocity.Y = num315;
                    npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
                    npc.ai[0] = 1f;
                    npc.ai[1] = 0f;
                    npc.netUpdate = true;
                    return;
                }
                if (npc.ai[0] == 1f)
                {
                    npc.velocity *= 0.99f;
                    npc.ai[1] += 1f;
                    if (npc.ai[1] >= 65f)
                    {
                        npc.netUpdate = true;
                        npc.ai[0] = 2f;
                        npc.ai[1] = 0f;
                        npc.velocity.X = 0f;
                        npc.velocity.Y = 0f;
                        return;
                    }
                }
                else
                {
                    npc.velocity *= 0.98f;
                    npc.ai[1] += 1f;
                    float num317 = npc.ai[1] / 120f;
                    num317 = 0.1f + num317 * 0.4f;
                    npc.rotation += num317 * (float)npc.direction;
                    if (npc.ai[1] >= 120f)
                    {
                        npc.netUpdate = true;
                        npc.ai[0] = 0f;
                        npc.ai[1] = 0f;
                        return;
                    }

                }
            }
            else
            {
                npc.velocity.X = 0f;
                npc.velocity.Y += 2f;
            }
        }
    }
}