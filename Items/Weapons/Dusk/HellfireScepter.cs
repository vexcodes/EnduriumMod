using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class HellfireScepter : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 53;
            item.magic = true;
            item.mana = 20;
            item.width = 46;
            item.height = 46;
            item.useTime = 41;
            item.useAnimation = 41;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 80000;
            item.rare = 3;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EmberBubble");
            item.shootSpeed = 11f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Scepter");
            Tooltip.SetDefault("");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
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
    }
}