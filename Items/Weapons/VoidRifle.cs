using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class VoidRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drained Spirit Staff");
            Tooltip.SetDefault("Casts void energy");
        }
        public override void SetDefaults()
        {
            item.damage = 52;
            item.magic = true;
            item.width = 72;
            item.height = 32;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Terraria.Item.buyPrice(0, 25, 0, 0);
            item.rare = 6;
            item.mana = 10;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("VoidBurst");
            item.shootSpeed = 10f;
        }
       /* public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("AmberDualshot"));
            recipe.AddIngredient(ItemID.DarkShard, 2);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num11 = Main.rand.Next(3, 4);
            for (int j = 0; j < num11; j++)
            {
                Vector2 vector = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                vector += player.velocity * 3f;
                vector.Normalize();
                vector *= (float)Main.rand.Next(35, 39) * 0.2f;
                int num12 = 52;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, vector.X, vector.Y, mod.ProjectileType("VoidBurst"), damage, knockBack, player.whoAmI, Main.mouseX, Main.mouseY);
            }
            return false;
        }
    }
}