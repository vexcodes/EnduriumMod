using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class TheInfernoofDecades : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 102;
            item.magic = true;
            item.mana = 22;
            item.width = 84;
            item.height = 84;
            item.useTime = 38;
            item.useAnimation = 8;
            item.useStyle = 5;
            Item.staff[item.type] = true;


            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;
            item.value = 800000;
            item.rare = 9;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FireBlast");
            item.shootSpeed = 11f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inferno of Decades");
            Tooltip.SetDefault("Releases a bullet hell of fire magic\nRight click to create a rain of fire");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)     //2 is right click
            {
                if (player.FindBuffIndex(mod.BuffType("FlamerainCooldown")) == -1)
                {
                    player.AddBuff(mod.BuffType("FlamerainCooldown"), 600);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -20f, mod.ProjectileType("FlamerainSpawn"), item.damage, item.knockBack, player.whoAmI);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                item.useTime = 31;
                item.useAnimation = 31;
                item.UseSound = SoundID.Item45;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse != 2)     //2 is right click
            {
                int i = Main.myPlayer;
                float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
                float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
                int numberProjectiles = 4 + Main.rand.Next(3);
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                int numberProjectiles2 = 4 + Main.rand.Next(3);
                for (int c = 0; c < numberProjectiles2; c++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Flame"), damage, knockBack, player.whoAmI);
                }
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 295, damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
                {
                    Vector2 value5 = Vector2.Normalize(new Vector2(num82, num83)) * 40f * item.scale;
                    if (Collision.CanHit(position, 0, 0, position + value5, 0, 0))
                    {
                        position += value5;
                    }
                    Vector2 vector24 = new Vector2(num82, num83);
                    vector24 *= 0.8f;
                    Vector2 value6 = vector24.SafeNormalize(-Vector2.UnitY);
                    float num203 = 0.0174532924f * -(float)player.direction;
                    int num2;
                    for (int num204 = 0; num204 <= 5; num204 = num2 + 2)
                    {
                        Projectile.NewProjectile(position, (vector24 + value6 * (float)num204 * 1f).RotatedBy((double)((float)num204 * num203), default(Vector2)), 711, item.damage, 1f, i, 0f, 0f);
                        num2 = num204;
                    }
                }
                
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("HellfireStaff"));
            recipe.AddIngredient(null, ("HellshardScepter"));
            recipe.AddIngredient(3870); //betsys wrath
            recipe.AddIngredient(1445); //inferno staff
            recipe.AddIngredient(null, ("SoulofDusk"), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}