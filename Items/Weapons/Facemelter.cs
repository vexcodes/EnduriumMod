using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Facemelter : ModItem
    {
        public override void SetDefaults()
        {

            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.shootSpeed = 10f;
            item.knockBack = 2f;
            item.width = 20;
            item.height = 12;
            item.damage = 46;
            item.rare = 10;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.ranged = true;
            item.channel = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Facemelter");
            item.shoot = mod.ProjectileType("Facemelter");
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Face Melter");
            Tooltip.SetDefault("Releases 4 notes in 4 different directions\nWhile playing you gain a boost to all stats\nA normal electric guitar. Drops an amplifier on right click for double the power!\nOnce you put your hands on the strings you can't stop\nWhile using it will prevent death, but if lethal damage is taken once you stop you immediatelly die");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse != 2)     //2 is right click
            {
                return true;
            }
            else
            {
                Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, mod.ProjectileType("FacemelterAmplifier"), item.damage, item.knockBack, item.owner);
                return false;
            }
            return true;
        }
    }
}
