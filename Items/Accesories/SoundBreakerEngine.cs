using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Accesories
{
    [AutoloadEquip(EquipType.Wings)]

    public class SoundBreakerEngine : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 26;

            item.value = Terraria.Item.buyPrice(0, 50, 0, 0);
            item.rare = 11;
            item.accessory = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sound Breaker Engine");
            Tooltip.SetDefault("Allows flight and running at the speed of sound\nAllows the ability to climb walls and dash\nGives a chance to dodge attacks");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed += 18f;
            player.rocketBoots += 8;
            player.moveSpeed *= 0.85f;
            player.blackBelt = true;
            player.dash = 1;
            player.wingTimeMax = 400;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.001f;
            ascentWhenRising = 1.3f;
            maxCanAscendMultiplier = 3f;
            maxAscentMultiplier = 1f;
            constantAscend = 0.6f;
        }


        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 6.5f;
            acceleration *= 3f;
        }
        public override bool WingUpdate(Player player, bool inUse)
        {
            if (inUse)
            {
                Dust.NewDust(player.position, player.width, player.height, 156, 0, 0, 0, Color.Green, 0.95f);
                base.WingUpdate(player, inUse);

            }
            return false;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 50);
            recipe.AddIngredient(null, "EndurianWings");
            recipe.AddIngredient(null, "CrystalflareRunners");
            //recipe.AddIngredient(null, "CrimsonWings/CorruptionWings"); - Made from evil materials
            recipe.AddIngredient(null, "NecroWings");
            recipe.AddIngredient(null, "ElementalBooster");
            //recipe.AddIngredient(null, "PlanetaryWings"); - Made from planetary crystals
            //recipe.AddIngredient(null, "GodKillerWings"); - Made from some post moon lord stuff
            //recipe.AddIngredient(null, "RadiatedWings"); - Made from post mech boss jungle materials
            //recipe.AddIngredient(null, "TheSoulVesel"); - The hollow warlock expert item
            //recipe.AddIngredient(null, "VoidflareWings"); - The Nightmare expert item
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}