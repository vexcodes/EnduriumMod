using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class CursedKnive : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 3;
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 1;
            item.expert = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed knive");
            Tooltip.SetDefault("'Holds cursed properties'\nCan be used to harvest a goliaths heart");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            for (int num731 = 0; num731 < 12; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 27, 0f, 0f, 100, default(Color), 1.7f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 1.8f;
                num3 = num731;
            }

            if (target.type == mod.NPCType("BloodlightGoliath"))
            {
                if (target.life <= 0)
                {
                    Terraria.Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, mod.ItemType("CursedHeart"));
                }
                for (int num731 = 0; num731 < 25; num731 = num3 + 1)
                {
                    int num732 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 27, 0f, 0f, 100, default(Color), 1.7f);
                    Main.dust[num732].noGravity = true;
                    Dust dust = Main.dust[num732];
                    dust.velocity *= 1.8f;
                    num3 = num731;
                }
            }
        }
    }
}
