using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class StarBlast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starlight");
            Tooltip.SetDefault("Rapidly fires bullets\nEvery third shot a star blast will be fired");
        }
        public override void SetDefaults()
        {
            item.damage = 32;
            item.ranged = true;
            item.width = 72;
            item.height = 32;
            item.useAnimation = 18;
            item.useTime = 6;
            item.reuseDelay = 8;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            item.rare = 6;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 22f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AmberDualshot"));
            recipe.AddIngredient(ItemID.LightShard, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public int Skiddadle = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Skiddadle += 1;
            if (Skiddadle >= 3)
            {
                Skiddadle = 0;
                int numberProjectiles = 1;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 0.5f, perturbedSpeed.Y * 0.5f, mod.ProjectileType("StarBurst"), damage, knockBack, player.whoAmI);
                }
            }
            return true;
        }
    }
}