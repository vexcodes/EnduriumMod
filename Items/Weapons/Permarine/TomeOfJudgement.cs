using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Permarine
{
    public class TomeOfJudgement : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 130;
            item.crit += 23;
            item.magic = true;
            item.mana = 28;
            item.width = 18;
            item.height = 22;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 900000;
            item.rare = 11;
            item.UseSound = SoundID.Item117;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GammaRift");
            item.shootSpeed = 5f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Judgement");
            Tooltip.SetDefault("'It awaits'\nCreates a consuming rift.");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
    }
}