using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using more_items_in_shops;
using Il2Cppfacility_H;

[assembly: MelonInfo(typeof(MoreItemsInShops), "More items in shops", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace more_items_in_shops;
public class MoreItemsInShops : MelonMod
{
    // After creating the shop
    [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCreateItemList))]
    private class Patch
    {
        public static void Postfix(ref fclDataShop_t pData)
        {
            /* SHOPS ID
             * 1 Shibuya
             * 2 Underpass
             * 3 Ikebukuro
             * 4 Asakusa
             * 5 Asakusa 2 (Collector)
             * 6 Tower of Kagutsuchi
             */

            pData.BuyItemList[pData.BuyItemCnt++] = 3; // Life Stone

            if (pData.Place != 2)
            {
                pData.BuyItemList[pData.BuyItemCnt++] = 58; // Divining Water
            }

            if (pData.Place != 5)
            {
                pData.BuyItemList[pData.BuyItemCnt++] = 1; // Muscle Drink
            }

            if (pData.Place != 2 && pData.Place != 5 && pData.Place != 6)
            {
                pData.BuyItemList[pData.BuyItemCnt++] = 6; // Chakra Drop
            }
        }
    }
}
