using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.TheReborn
{
    public class StaffotheDragonHydra : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 150;
            item.mana = 10;
            item.width = 50;
            item.height = 50;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2f;
            item.value = 50000;
            item.rare = 8;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FrostDragon_Head");
            item.shootSpeed = 10f;
            item.summon = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of the DragonHydra");
            Tooltip.SetDefault("Summons a gigant hydra to fight for you");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            float neededSlots = 1;
            float foundSlotsCount = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];
                if (p.active && p.minion && p.owner == player.whoAmI)
                {
                    foundSlotsCount += p.minionSlots;
                    if (foundSlotsCount + neededSlots > player.maxMinions)
                        return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StaffoftheFrostHydra);
            recipe.AddIngredient(null, ("CoreofRebirth"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /*float num82 = (float)Main.mouseX + Main.screenPosition.X - position.X;
            float num83 = (float)Main.mouseY + Main.screenPosition.Y - position.Y;
            int num185 = -1;
            int num186 = -1;
            int i = Main.myPlayer;
            int num2;
            int num77 = item.damage;
            float num78 = item.knockBack;
            for (int num187 = 0; num187 < 1000; num187 = num2 + 1)
            {
                if (Main.projectile[num187].active && Main.projectile[num187].owner == Main.myPlayer)
                {
                    if (num185 == -1 && Main.projectile[num187].type == mod.ProjectileType("FrostDragon_Head"))
                    {
                        num185 = num187;
                    }
                    if (num186 == -1 && Main.projectile[num187].type == mod.ProjectileType("FrostDragon_Tail"))
                    {
                        num186 = num187;
                    }
                    if (num185 != -1 && num186 != -1)
                    {
                        break;
                    }
                }
                num2 = num187;
            }
            if (num185 == -1 && num186 == -1)
            {
                num82 = 0f;
                num83 = 0f;
                position.X = (float)Main.mouseX + Main.screenPosition.X;
                position.Y = (float)Main.mouseY + Main.screenPosition.Y;

                int num188 = Projectile.NewProjectile(position.X, position.Y, num82, num83, mod.ProjectileType("FrostDragon_Head"), num77, num78, i, 0f, 0f);
                num188 = Projectile.NewProjectile(position.X, position.Y, num82, num83, mod.ProjectileType("FrostDragon_Body"), num77, num78, i, (float)num188, 0f);
                int num189 = num188;
                num188 = Projectile.NewProjectile(position.X, position.Y, num82, num83, mod.ProjectileType("FrostDragon_Body2"), num77, num78, i, (float)num188, 0f);
                Main.projectile[num189].localAI[1] = (float)num188;
                num189 = num188;
                num188 = Projectile.NewProjectile(position.X, position.Y, num82, num83, mod.ProjectileType("FrostDragon_Tail"), num77, num78, i, (float)num188, 0f);
                Main.projectile[num189].localAI[1] = (float)num188;
            }
            else if (num185 != -1 && num186 != -1)
            {
                int num190 = Projectile.NewProjectile(position.X, position.Y, num82, num83, mod.ProjectileType("FrostDragon_Body"), num77, num78, i, (float)Projectile.GetByUUID(Main.myPlayer, Main.projectile[num186].ai[0]), 0f);
                int num191 = num190;
                num190 = Projectile.NewProjectile(position.X, position.Y, num82, num83, mod.ProjectileType("FrostDragon_Body2"), num77, num78, i, (float)num190, 0f);
                Main.projectile[num191].localAI[1] = (float)num190;
                Main.projectile[num191].netUpdate = true;
                Main.projectile[num191].ai[1] = 1f;
                Main.projectile[num190].localAI[1] = (float)num186;
                Main.projectile[num190].netUpdate = true;
                Main.projectile[num190].ai[1] = 1f;
                Main.projectile[num186].ai[0] = (float)Main.projectile[num190].projUUID;
                Main.projectile[num186].netUpdate = true;
                Main.projectile[num186].ai[1] = 1f;
            }
            */
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }
}