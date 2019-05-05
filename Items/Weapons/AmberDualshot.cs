using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class AmberDualshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amber Dualshot");
            Tooltip.SetDefault("Rapidly fires 2 bullets");
        }
        public override void SetDefaults()
        {
            item.damage = 28;
            item.ranged = true;
            item.width = 72;
            item.height = 32;
            item.useAnimation = 18;
            item.useTime = 9;
            item.reuseDelay = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FossilOre, 20);
            recipe.AddIngredient(ItemID.Amber, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
    }
}