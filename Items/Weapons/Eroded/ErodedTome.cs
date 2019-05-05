using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Eroded
{
    public class ErodedTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Tome");
            Tooltip.SetDefault("Fires a homing bolt");
        }
        public override void SetDefaults()
        {
            item.damage = 56;
            item.magic = true;
            item.width = 72;
            item.height = 32;
            item.useAnimation = 22;
            item.useTime = 22;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            Item.staff[item.type] = true;
            item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            item.rare = 3;
            item.autoReuse = true;
            item.mana = 11;
            item.UseSound = SoundID.Item43;
            item.shoot = mod.ProjectileType("LostSoul");
            item.shootSpeed = 16f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 20);
            recipe.AddIngredient(null, ("RuneofFear"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}