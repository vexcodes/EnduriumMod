using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Items.Weapons.Rift
{
    public class ShadowRiftRang : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 86;
            item.thrown = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 13;
            item.useAnimation = 13;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = Terraria.Item.buyPrice(0, 15, 35, 0);
            item.rare = 8;
            item.shootSpeed = 16f;
            item.shoot = mod.ProjectileType("ShadowRiftRang");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Caller");
            Tooltip.SetDefault("Hitting an enemy marks it\nHomes in on marked enemies, except like not cause kitty didnt finish it");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int data = Projectile.NewProjectile(position.X, position.Y -= 14, speedX, speedY, item.shoot, damage, knockBack, player.whoAmI); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("RiftShard"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}