using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Yeeter3 : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 65;
            item.thrown = true;
            item.noMelee = false;
            item.width = 14;
            item.height = 36;
            item.useTime = 21;
            item.crit = 40;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = Terraria.Item.buyPrice(0, 32, 0, 0);
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Yeeter3");
            item.shootSpeed = 12f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            item.noUseGraphic = true;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int data = Projectile.NewProjectile(position.X, position.Y -= 14, speedX, speedY, item.shoot, damage, knockBack, player.whoAmI); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Prophecy");
            Tooltip.SetDefault("Sticks to enemies\nStacking enough javelins in an enemy creates homing shards");
        }
    }
}
