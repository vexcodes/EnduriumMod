using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.BloodlightShaman
{
    public class VampirePortalStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 14;
            item.summon = true;
            item.mana = 10;
            item.width = 36;
            item.height = 36;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2.25f;
            item.value = 45000;
            item.rare = 2;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloodOrb");
            item.shootSpeed = 6f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Portal Scepter");
            Tooltip.SetDefault("Creates an orb of blood energy\nOnly 1 orb can be active at a time");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodlightBar"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}