using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class Contagion : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 30;
            item.melee = true;
            item.width = 44;
            item.height = 50;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Contagion");
            Tooltip.SetDefault("Infects the target");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BloodFangFlame"), 300);
        }
    }
}
