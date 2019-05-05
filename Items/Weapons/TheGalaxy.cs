using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EnduriumMod.Items.Weapons
{
    public class TheGalaxy : ModItem
    {
        public const float Num = 0f;
        public override void SetDefaults()
        {

            item.damage = 150;
            item.melee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.channel = true;
            item.knockBack = 4f;
            item.value = Terraria.Item.sellPrice(1, 2, 25, 0);
            item.rare = 10;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Stardust");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
        }
        public int ShockedHowizon = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Galaxy");
            Tooltip.SetDefault("'The fullfiled power from the center of the universe right in your hands'/nChanges beetwen 4 different projectiles");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            ShockedHowizon += 1;
            if (ShockedHowizon == 1)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Vortex"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            if (ShockedHowizon == 2)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Solar"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            if (ShockedHowizon == 3)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Nebula"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            if (ShockedHowizon == 4)
            {
                ShockedHowizon = 0;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Stardust"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
