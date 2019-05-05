using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.BloodFang
{
    public class BloodRecluse : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Follower");
        }
        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 44;
            npc.damage = 28;
            npc.defense = 6;
            npc.lifeMax = 60;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 160f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DesertScorpionWalk];
            animationType = NPCID.DesertScorpionWalk;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(8) == 0)
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCherry"));

            }
            if (Main.rand.Next(18) == 0)
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ErodedPrism"));

            }
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodFangCore"), Main.rand.Next(6, 9));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
            return spawnInfo.player.ZoneOverworldHeight && !Main.dayTime && !Main.bloodMoon && !spawnInfo.playerInTown && !spawnInfo.player.ZoneTowerStardust && !spawnInfo.player.ZoneTowerSolar && !spawnInfo.player.ZoneTowerVortex && !spawnInfo.player.ZoneTowerNebula ? 0.07f : 0f;

        }
    }
}