    using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class JadeHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 10000;
            item.rare = 6;
            item.defense = 7; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jade Helmet");
            Tooltip.SetDefault("Increases magic damage by 8%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("JadeBody") && legs.type == mod.ItemType("JadeLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
			player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Your magic has a chance to inflict 'Nature Sting' dealing additional damage\nIncreases magic damage by 5%";
                player.magicDamage += 0.05f;
				     		((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).NatureMagic = true;
	}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("Jade"), 19);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
