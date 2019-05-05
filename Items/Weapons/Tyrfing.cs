using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Tyrfing : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 120;
            item.melee = true;
            item.width = 56;
            item.height = 78;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;

            item.knockBack = 1;
            item.value = 25000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tyrfing");
            Tooltip.SetDefault("Pierces through armor\nCan be used to harvest a goliaths heart");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            int num3;
            for (int num731 = 0; num731 < 24; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 27, 0f, 0f, 100, default(Color), 1.7f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 1.8f;
                num3 = num731;
            }

            if (target.type == mod.NPCType("BloodlightGoliath"))
            {
                if (target.life <= 0)
                {
                    Terraria.Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, mod.ItemType("CursedHeart"));
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CursedKnive");
            recipe.AddIngredient(null, "RuneofFear", 25);
            recipe.AddIngredient(null, "BoneScrap", 25);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
