using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TrueVampireClawStaff : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 92;
            item.magic = true;
            item.mana = 16;
            item.width = 70;
            item.height = 72;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.crit = 20;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 8.25f;
            item.value = 80000;
            item.rare = 7;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TrueBloodyBeam");
            item.shootSpeed = 11f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodClawStaff"));
            recipe.AddIngredient(ItemID.Ichor, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.DarkShard, 2);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Vampire Claw Staff");
            Tooltip.SetDefault("Creates several beams of blood energy\nUpon hitting an enemy the beam will split\nHitting an enemy will steal health");
        }
    }
}