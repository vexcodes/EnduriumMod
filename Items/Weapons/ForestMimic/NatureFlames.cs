using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace EnduriumMod.Items.Weapons.ForestMimic
{
    public class NatureFlames : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 46;  //The damage stat for the Weapon.
            item.ranged = true;    //This defines if it does Ranged damage and if its effected by Ranged increasing Armor/Accessories.
            item.width = 62;  //The size of the width of the hitbox in pixels.
            item.height = 26;    //The size of the height of the hitbox in pixels.


            item.useTime = 13;   //How fast the Weapon is used.
            item.useAnimation = 13;     //How long the Weapon is used for.
            item.useStyle = 5;   //The way your Weapon will be used, 1 is the regular sword swing for example
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.25f;  //The knockback stat of your Weapon.
            item.UseSound = SoundID.Item34; //The sound played when using your Weapon
            item.value = Terraria.Item.buyPrice(0, 15, 0, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 7;   //The color the title of your Weapon when hovering over it ingame  
            item.autoReuse = true;   //Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
            item.shoot = mod.ProjectileType("NatureFlame");   //This defines what type of projectile this weapon will shot
            item.shootSpeed = 9.5f; //This defines the projectile speed when shoot , for flamethrower this make how far the flames can go
            item.useAmmo = AmmoID.Gel; //This defines what ammo this weapon should use.
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloomthrower");
            Tooltip.SetDefault("75% chance to not consume gel");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("TropicalFragment"), 2);
            recipe.AddRecipeGroup("Tier3HMBars", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool ConsumeAmmo(Player player) //this is where you can modify the ammo consuming
        {
            return Main.rand.NextFloat() > .75f;//this make so the weapon has 50% chance to not consume ammo, in this case gel
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2; // This defines how many projectiles to shot
            float rotation = MathHelper.ToRadians(5);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 12f; //this defines the distance of the projectiles form the player when the projectile spawns
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .6f; // This defines the projectile roatation and speed. .4f == projectile speed
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
