using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Ancient
{
    public class AncientBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 29;
            item.melee = true;
            item.width = 42;
            item.height = 46;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            
            item.knockBack = 5;
            item.value = 18000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 269);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primeval Blade");
            Tooltip.SetDefault("");
        }
						        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AncientMandible"), 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
