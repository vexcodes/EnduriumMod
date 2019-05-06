using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
namespace EnduriumMod.Items.Accesories
{
    public class CharmofSacrifises : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charm of Sacrifises");
            Tooltip.SetDefault("Killing enemies recovers a small amount of health\nTurns you into a demonic being");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.accessory = true;
            item.value = 150000;
            item.rare = 6;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(527, 2);
            recipe.AddIngredient(520, 25);
            recipe.AddIngredient(521, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>();
            p.CharmofSacrifises = true;
            p.CharmSAccPrevious = true;
            p.CharmHide = true;
            player.lifeRegen -= 10;

            if (hideVisual)
            {
                p.CharmSHide = true;
            }
        }
    }

    public class DemonHead : EquipTexture
    {
        public override bool DrawHead()
        {
            return false;
        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            if (Main.rand.Next(3) < 2)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 12, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].velocity.Y += 0.25f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[dust].scale *= 0.5f;
                }
            }

        }
    }

    public class DemonBody : EquipTexture
    {
        public override bool DrawBody()
        {
            return false;
        }
    }

    public class DemonLeg : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
}