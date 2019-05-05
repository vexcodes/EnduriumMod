using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Ancient
{
    public class AncientSentryStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primeval Wand");
            Tooltip.SetDefault("'Summons a sand spirit to fight for you'");
        }
        public override void SetDefaults()
        {

            item.damage = 18;
            item.summon = true;
            item.mana = 14;
            item.width = 46;
            item.height = 46;
            item.useTime = 37;
            item.useAnimation = 37;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 20000;
            item.rare = 4;
            item.UseSound = SoundID.Item72;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SandSpirit");
            item.shootSpeed = 11f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AncientMandible"), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}