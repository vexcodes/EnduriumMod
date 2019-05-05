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
            Tooltip.SetDefault("'A collector of souls'");
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