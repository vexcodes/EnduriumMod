using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class BoneBlade : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 32;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;

            item.knockBack = 4;
            item.value = 35000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 121);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Blade");
            Tooltip.SetDefault("");
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BoneScrap"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}