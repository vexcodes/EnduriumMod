using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Weapons.Acid
{
    public class AcidRain : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 56;
            item.magic = true;
            item.mana = 15;
            item.width = 28;
            item.height = 30;
		 	item.useAnimation = 24;
			item.useTime = 7;
			item.reuseDelay = 25;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 6.25f;
            item.value = 45000;
            item.rare = 5;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AcidBolt");
            item.shootSpeed = 12f;
        }
			  					           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AcidCore"), 20);
						            recipe.AddIngredient(null, ("DarkDust"), 15);
												recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Rain");
            Tooltip.SetDefault("Casts furious bouncy balls of acid");
        }
    }
}