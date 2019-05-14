using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.HollowWarlock
{
    public class SigilofHollow : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 16;
            item.height = 16;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 2;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.shoot = mod.ProjectileType("HollowWarlockSpawn");
            item.shootSpeed = 0f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sigil of Hollow");
            Tooltip.SetDefault("Summons the Hollow Warlock");
        }

        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("HollowWarlockSpawn")] > 0 || Main.dayTime || NPC.AnyNPCs(mod.NPCType("TheKeeperofHollow2")))
            {
                return false;
            }
            if (!player.ZoneHoly)
            {
                return false;
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            Projectile.NewProjectile(player.position.X, player.position.Y - 80, 0f, 1f, mod.ProjectileType("HollowWarlockSpawn"), 0, 0f, Main.myPlayer, 0f, 0f);
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("HolySilver"), 6);
            recipe.AddIngredient(null, ("IceEnergy"), 2);
            recipe.AddTile(null, "SoulForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}