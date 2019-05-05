using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.HollowWarlock
{
    public class StarFlowerStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 85;
            item.magic = true;
            item.width = 62;
            item.height = 62;
            item.useTime = 46;

            item.useAnimation = 46;
            item.useStyle = 1;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4f;
            item.value = 1000000;
            item.rare = -12;
            item.mana = 20;
            item.UseSound = SoundID.Item67;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Flower Staff");
            Tooltip.SetDefault("Creates a star flower at cursors position");
        }
        public override bool UseItem(Player player)
        {
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 4f, 0f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, -4f, 0f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 4f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, -4f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);

            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 3f, 3f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, -3f, 3f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 3f, -3f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, -3f, -3f, mod.ProjectileType("StarSpell"), item.damage, item.knockBack, item.owner);
            return true;
        }
    }
}
