using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.TheSpiritOfBloom
{
    public class TheBloomingFire : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.maxStack = 20;

            item.rare = -12;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
						item.noUseGraphic = true;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
		        public override bool CanUseItem(Player player)
        {
            return Main.dayTime && !NPC.AnyNPCs(mod.NPCType("TheSpiritOfBloom"));
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheSpiritOfBloom"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Blooming Fire");
            Tooltip.SetDefault("Summons the guardian of the forest\nUse in the light of the sun");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(9, 7));
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
								        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald, 5);
            recipe.AddRecipeGroup("PlatinumBars", 8);
			            recipe.AddIngredient(null, ("NatureEssence"), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}