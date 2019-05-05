using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class FlameWrathKatana : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 40;
            item.melee = true;

            item.width = 46;
            item.height = 46;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;


            item.noMelee = false; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 80000;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Flame");
            item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("FieryTissue"), 15);
            recipe.AddIngredient(null, ("DuskSteel"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flamewrath Katana");
            Tooltip.SetDefault("Ocasionally releases flames");
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(6) == 0)
            {
                return true;
            }
            return false;
        }
    }
}