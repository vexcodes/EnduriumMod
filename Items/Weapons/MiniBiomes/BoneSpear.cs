using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class BoneSpear : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;

            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.maxStack = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 1, 25, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType("BoneSpear");
            item.shootSpeed = 8f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Pike");
            Tooltip.SetDefault("Hitting enemies releases flares");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BoneScrap"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
