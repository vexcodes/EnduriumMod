using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.ShardofFlame
{
    public class TripmineStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 54;
            item.magic = true;
            item.mana = 12;
            item.width = 62;
            item.height = 64;
            item.useTime = 39;
            item.useAnimation = 39;
            item.useStyle = 5;
            Item.staff[item.type] = true;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 50000;
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TripmineStaff");
            item.shootSpeed = 12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddIngredient(null, ("MagmaCore"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tripmine Staff");
            Tooltip.SetDefault("'Fires a bolt of magma energy");
        }
    }
}