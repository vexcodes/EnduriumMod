using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.BloodlightShaman
{
    public class SacrificialIdol : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 20;

            item.rare = 2;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacrificial Idol");
            Tooltip.SetDefault("Activate to summon the bloodlight shaman");
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("BloodlightGoliath")) && Main.bloodMoon;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BloodlightGoliath"));
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodDust"), 20);
            recipe.AddRecipeGroup("PlatinumBars", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}