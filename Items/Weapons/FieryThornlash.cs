using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class FieryThornlash : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 75;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 8;
            item.value = 246000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("FieryThornlash");
            item.shootSpeed = 18f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Thornlash");
            Tooltip.SetDefault("'A powerfull weapon forged with pure magma'\nExplodes after hitting 3 enemies");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodSpikelash"));
            recipe.AddIngredient(null, ("DuskSteel"), 25);
            recipe.AddIngredient(null, ("FieryTissue"), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}

