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
    public class PrismCrystalHead : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 26;

            item.value = 100000;
            item.rare = 5;
            item.defense = 2; //42
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Voidwalker Helmet");
            Tooltip.SetDefault("Increases melee damage by 9%");
        }


        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == mod.ItemType("PrismCrystalBody") && legs.type == mod.ItemType("PrismCrystalLegs");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases melee and movement speed by 22%\nWhen below 25% health melee damage is increased by 18%\nMelee weapons which fire a projectile also fire a Void Pulse that deals half of the weapons damage";
            player.moveSpeed += 0.22f;
            player.meleeSpeed += 0.22f;
            if (player.statLife <= (player.statLifeMax2 * 0.25f))
            {
                player.meleeDamage += 0.18f;
            }
            ((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Voidwalker = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.09f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("CursedHeart"));
            recipe.AddIngredient(null, ("PrismShard"), 5);
            recipe.AddIngredient(null, ("MagicPowder"), 6);
            recipe.AddIngredient(null, ("CrypticPowerCell"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}