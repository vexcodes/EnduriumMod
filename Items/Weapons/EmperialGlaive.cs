using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class EmperialGlaive : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 45;
            item.thrown = true;
            item.useTime = 42;
            item.useAnimation = 42;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 2f;
            item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EmperialGlaive");
            item.shootSpeed = 12f;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emperial Glaive");
            Tooltip.SetDefault("Goes back to the player only upon releasing the trigger");
        }
    }
}