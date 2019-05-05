using Terraria;
using Terraria.ModLoader;

namespace EnduriumMod.Buffs
{
    public class CharmofLuna : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Crystal Being");
            Description.SetDefault("Perks!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>();

            // We use blockyAccessoryPrevious here instead of blockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
            if (p.CharmAccPrevious)
            {
                p.CharmEffect = true;
                player.jumpSpeedBoost += 1.5f;
                player.extraFall += 15;
                // Some other effects:
                //player.lifeRegen++;
                //player.meleeCrit += 2;
                //player.meleeDamage += 0.051f;
                //player.meleeSpeed += 0.051f;
                //player.statDefense += 3;
                //player.moveSpeed += 0.05f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
