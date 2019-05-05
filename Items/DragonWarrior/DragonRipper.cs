using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.DragonWarrior
{
    public class DragonRipper : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 100;
            item.melee = true;
            item.width = 70;
            item.height = 74;
            item.maxStack = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 50, 25, 0);
            item.rare = 8;
            item.shoot = mod.ProjectileType("DragonRipper");
            item.shootSpeed = 18f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("DragonShard"), 16);
            recipe.AddIngredient(null, ("DragonBlood"), 16);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddTile(null, "AltarofFire");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Ripper");
            Tooltip.SetDefault("Pierces targets");
        }
    }
}
	