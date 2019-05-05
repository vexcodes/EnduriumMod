using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TruePutridStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 82;
            item.magic = true;
            item.mana = 15;
            item.width = 60;
            item.height = 72;
            item.useTime = 42;
            item.useAnimation = 42;
            item.useStyle = 1;


            item.noMelee = false; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 80000;
            item.rare = 7;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TruePutridPlague");
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("PutridStaff"));
            recipe.AddIngredient(ItemID.CursedFlame, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.DarkShard, 2);
            recipe.AddIngredient(null, ("DarkDust"), 15);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Putrid Shade Scepter");
            Tooltip.SetDefault("Lunches a nuclear plague spore into the air\nThe plague will consume enemies and inflict several debuffs\nWhen enemies are consumed the plague releases additional spores");
        }
    }
}