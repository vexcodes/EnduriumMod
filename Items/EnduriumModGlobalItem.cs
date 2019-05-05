
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using EnduriumMod;

namespace EnduriumMod.Items
{
    public class EnduriumModGlobalItem : GlobalItem
    {
        public override bool ConsumeAmmo(Item item, Player player)
        {
            if (((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).RoyalQuiver)
            {
                if (item.ranged)
                {
                    if (item.shoot == 1)
                    {
                        if (Main.rand.NextFloat() < 0.4f)

                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (player.GetModPlayer<MyPlayer>(mod).OutburstSpeed >= 1f && item.type == mod.ItemType("OutburstOutbreak"))
            {
                return (player.GetModPlayer<MyPlayer>(mod).OutburstSpeed);
            }
            if (player.GetModPlayer<MyPlayer>(mod).StarExcalibur >= 1f && item.type == mod.ItemType("StarClaymore"))
            {
                return (player.GetModPlayer<MyPlayer>(mod).StarExcalibur);
            }
            if (player.GetModPlayer<MyPlayer>(mod).ThunderStrike >= 1f && item.type == mod.ItemType("ThunderStrike"))
            {
                return (player.GetModPlayer<MyPlayer>(mod).ThunderStrike);
            }
            if (player.GetModPlayer<MyPlayer>(mod).ThrowingSpeed >= 1f && item.thrown)
            {
                return (player.GetModPlayer<MyPlayer>(mod).ThrowingSpeed);
            }

            return 1f;
        }
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.EaterOfWorldsBossBag && Main.rand.NextBool(3)) // 33.33% chance
            {
                player.QuickSpawnItem(mod.ItemType("EatersTooth"));
            }
            if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag && Main.rand.NextBool(3)) // 33.33% chance
            {
                player.QuickSpawnItem(mod.ItemType("EyeofFlesh"));
            }
        }
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (crit && ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).ChaosCrit)
            {
                damage = (int)(damage * 1.5f);
            }
        }
   

        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {

            if (extractType == (mod.ItemType("OreCluster")))
            {

                if (Main.rand.NextFloat() < 0.55f)
                {
                    resultStack = (Main.rand.Next(2, 6));
                    resultType = (mod.ItemType("SkyLamentOre"));

                }
                if (Main.rand.NextFloat() < 0.965f)
                {
                    resultStack = (Main.rand.Next(1, 7));
                    resultType = (mod.ItemType("BoneScrap"));

                }
                if (Main.rand.NextFloat() < 0.565f)
                {
                    resultStack = (Main.rand.Next(1, 2));
                    resultType = (mod.ItemType("AncientMandible"));
                }
                if (Main.rand.NextFloat() < 0.055f)
                {
                    resultStack = 1;
                    resultType = (mod.ItemType("BlankTab"));

                }
                if (Main.rand.NextFloat() < 0.05f)
                {
                    resultStack = (Main.rand.Next(1, 4));
                    resultType = ItemID.DemoniteOre;

                }
                if (Main.rand.NextFloat() < 0.05f)
                {
                    resultStack = (Main.rand.Next(1, 4));
                    resultType = ItemID.CrimtaneOre;

                }
                if (Main.rand.NextFloat() < 0.1f)
                {
                    resultStack = (Main.rand.Next(1, 4));
                    resultType = ItemID.Diamond;

                }
                if (Main.rand.NextFloat() < 0.1f)
                {
                    resultStack = (Main.rand.Next(1, 4));
                    resultType = ItemID.Ruby;

                }
            }
        }
    }
}