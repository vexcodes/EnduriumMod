using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;

namespace EnduriumMod
{
    public class SoulGemCurrency : CustomCurrencySingleCoin
    {
        public Color SoulGemColor = Color.Purple;

        public SoulGemCurrency(int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
        {
        }

        public override void GetPriceText(string[] lines, ref int currentLine, int price)
        {
            Color color = SoulGemColor * ((float)Main.mouseTextColor / 255f);
            lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
                {
                    color.R,
                    color.G,
                    color.B,
                    Lang.tip[50],
                    price,
                    "Soul Gems"
                });
        }
    }
}