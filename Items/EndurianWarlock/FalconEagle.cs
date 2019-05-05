using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class FalconEagle : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 46;
            item.ranged = true;
            item.width = 40;
            item.height = 26;
            item.useTime = 10;
            item.crit = 45;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item98;
            item.autoReuse = true;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Jungle Eagle");
      Tooltip.SetDefault("");
    }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ElderBranch"), 20);
            recipe.AddTile(null, "AltarofNature");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
