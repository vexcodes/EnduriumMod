using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EnduriumMod.Items.Armor
{
    public class TheFrozenMoonlight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charm of Luna");
            Tooltip.SetDefault("Turns the holder into a Crystal being\nProvides greater vertical and horizontal movement options\nJumping creates a freezing explosion");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.accessory = true;
            item.expert = true;
            item.value = 150000;
            item.rare = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>();
            p.CharmofLuna = true;
            p.CharmAccPrevious = true;
            player.maxFallSpeed = 24f;
            player.maxRunSpeed = 5f;
            player.gravity = 0.30f;
            p.CharmSHide = true;
            if (hideVisual)
            {
                p.CharmHide = true;
            }
            player.autoJump = true;
        }
    }

    public class FrostHead : EquipTexture
    {
        public override bool DrawHead()
        {
            return false;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {

            if (Main.rand.Next(4) == 0)
            {
                int num38 = Dust.NewDust(new Vector2(player.position.X - 2f, player.position.Y + (float)player.height - 2f), player.width + 2, 2, 132, 0f, 0f, 100, default(Microsoft.Xna.Framework.Color), 1.5f);
                Main.dust[num38].noGravity = true;
                Main.dust[num38].noLight = true;
                Dust dust2 = Main.dust[num38];
                dust2.velocity *= 0f;
            }
            if (Main.rand.Next(3) < 2)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 132, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].velocity.Y += 0.25f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[dust].scale *= 0.5f;
                }
            }

        }
    }

    public class FrostBody : EquipTexture
    {
        public override bool DrawBody()
        {
            return false;
        }
    }

    public class FrostLeg : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
}