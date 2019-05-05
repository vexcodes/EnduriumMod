using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TheSpewer : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 49;
            item.thrown = true;
            item.width = 30;
            item.height = 44;
            item.useTime = 21;
            item.useAnimation = 21;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Terraria.Item.buyPrice(0, 25, 35, 0);
            item.rare = 6;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType("GreenyPetal");
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Spewer");
            Tooltip.SetDefault("");
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
		            switch (Main.rand.Next(3))
            {
                case 0: type = mod.ProjectileType("GreenyPetal"); break;
                case 1: type = mod.ProjectileType("GreenyPetal"); break;
                case 2: type = mod.ProjectileType("PinkyPetal"); break;
            }
            int num6 = Main.rand.Next(1, 3);
            for (int index = 0; index < num6; ++index)
            {
                float num7 = speedX;
                float num8 = speedY;
                float SpeedX = speedX + (float)Main.rand.Next(-30, 31) * 0.05f;
                float SpeedY = speedY + (float)Main.rand.Next(-30, 31) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, (int)((double)damage * 1), knockBack, player.whoAmI, 0.0f, 0.0f);
            }
            return false;
        }
    }
}