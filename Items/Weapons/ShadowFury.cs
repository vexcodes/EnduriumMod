using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class ShadowFury : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 50;
            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(10) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 37);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Fury");
            Tooltip.SetDefault("Inflitcts 'Shadow touch'\n'Shadows shall strike'");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("ShadowTouch"), 360);
        }
    }
}
