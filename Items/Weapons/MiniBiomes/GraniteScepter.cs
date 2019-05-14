using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class GraniteScepter : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.mana = 8;
            item.width = 50;
            item.height = 50;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2f;
            item.value = 500000;
            item.rare = 8;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GraniteCutter");
            item.shootSpeed = 10f;
            item.summon = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Scepter");
            Tooltip.SetDefault("Summons a Granite Sawblade to cut through enemies for you!");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }
}