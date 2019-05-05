using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.NPCTied
{
    public class SpiritOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Orb");
            Tooltip.SetDefault("Crates 2 orbiting leaves, right clicking causes all stored leaves to launch towards your mouse cursor");
        }
        public override void SetDefaults()
        {

            item.damage = 18;
            item.magic = true;
            item.mana = 5;
            item.width = 68;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2f;
            item.value = 7500;
            item.rare = 2;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SpiritOrb");
            item.shootSpeed = 0f;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 5;
                Item.staff[item.type] = true;
                item.useTime = 40;
                item.useAnimation = 40;
            }
            else
            {
                item.useStyle = 5;
                Item.staff[item.type] = true;
                item.useTime = 24;
                item.useAnimation = 24;
            }
            return base.CanUseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.altFunctionUse != 2)
            {
                modPlayer.UsedSpiritOrb = false;
                Projectile.NewProjectile(position.X, position.Y, 0f, 0f, type, damage, knockBack, player.whoAmI, 0);
                Projectile.NewProjectile(position.X, position.Y, 0f, 0f, type, damage, knockBack, player.whoAmI, 180);
            }
            if (player.altFunctionUse == 2)
            {
                modPlayer.UsedSpiritOrb = true;
            }
            return false;
        }
    }
}