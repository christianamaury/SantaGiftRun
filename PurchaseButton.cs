using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{

    public enum PurchaseType { removeAds, minimumCoins, mediumCoins, largeCoins};
    public PurchaseType purchaseType;

    public void ClickOnPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.removeAds:
                IAPurchase.Instance.BuyRemoveAllAds();
                break;

            case PurchaseType.minimumCoins:
                IAPurchase.Instance.BuyMinimumCoins();
                break;

            case PurchaseType.mediumCoins:
                IAPurchase.Instance.BuyMediumCoins();
                break;

            case PurchaseType.largeCoins:
                IAPurchase.Instance.BuyLargeCoins();
                break;
        }
    }
}
