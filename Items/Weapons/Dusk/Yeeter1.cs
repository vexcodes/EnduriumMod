using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Dusk
{
    public class Yeeter1 : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 46;
            item.thrown = true;
            item.noMelee = false;
            item.width = 14;
            item.height = 36;
            item.useTime = 20;
            item.crit = 35;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Yeeter1");
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
            DisplayName.SetDefault("The Thornvile");
            Tooltip.SetDefault("Sticks to enemies\nStacking enough javelins in an enemy causes an eruption");
        }
    }
}
