using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.EndurianWarlock
{
    public class PlagueSigil : ModItem
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
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Plague Sigil");
      Tooltip.SetDefault("'A forest titan's curse'");
    }
        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime || NPC.AnyNPCs(mod.NPCType("EndurianWarlock")) || NPC.AnyNPCs(mod.NPCType("EndurianSpirit")))
            {
                return false;
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("EndurianWarlock"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("DarkDust"), 15);
            recipe.AddIngredient(null, ("HolySilver"), 10);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
