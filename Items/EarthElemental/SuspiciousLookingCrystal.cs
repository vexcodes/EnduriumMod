using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.EarthElemental
{
    public class SuspiciousLookingCrystal : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 20;

            item.rare = 6;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return Main.dayTime && player.ZoneJungle && !NPC.AnyNPCs(mod.NPCType("TheSwarm"));
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheSwarm"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("An ancient rock");
            Tooltip.SetDefault("Summons an ancient elemental\nUse in the light of the sun while at the jungle");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("PlatinumBars", 8);
            recipe.AddIngredient(null, ("TropicalFragment"), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}