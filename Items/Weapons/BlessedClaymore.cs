using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class BlessedClaymore : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 29;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 11;
            item.useAnimation = 11;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 300000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blessed Claymore");
            Tooltip.SetDefault("");
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 269);
            }
        }
    }
}