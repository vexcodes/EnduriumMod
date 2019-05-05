using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.MiniBiomes
{
    public class GraniteSword : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 20;
            item.melee = true;
            item.width = 52;
            item.height = 62;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            
            item.knockBack = 6;
            item.value = 35000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Sword");
            Tooltip.SetDefault("Rips through enemy defense");
        }
			public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
    {
	    	target.AddBuff(mod.BuffType("GraniteShatter"), 360);
   
	}
							    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.Next(8) == 0)
        {
        	int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
        }
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("GraniteScale"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
