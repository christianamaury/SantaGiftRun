using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Purchasing;

public class IAPurchase : MonoBehaviour, IStoreListener
{

    public static IAPurchase Instance {get; set;}

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //..Products, so far only remove Ads
    private string removeAllAds = "Remove_Ads";
    private string minimumCoins = "300 Coins";
    private string mediumCoins = "640 Coins";
    private string largeCoins = "1,150 Coins";


    public bool removeAllAds_IAP = false;

    private void Awake()
    {
        Instance = this;

        //..Don't destroy this case object when changing scenes
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //..Adding Products
        builder.AddProduct(removeAllAds, ProductType.NonConsumable);
        builder.AddProduct(minimumCoins, ProductType.Consumable);
        builder.AddProduct(mediumCoins, ProductType.Consumable);
        builder.AddProduct(largeCoins, ProductType.Consumable);

        //..Choose if your product is consumable or not
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null & m_StoreExtensionProvider != null;
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, removeAllAds, StringComparison.Ordinal))
        {
            Debug.Log("All Ads has been removed.");

            //..Bool is now true, User removed all Ads.
            //Bottle.Instance.removeAllAds_IAP = true;
            removeAllAds_IAP = true;
        }
        else
        {
            Debug.Log("Purchased has failed. Please try again.");
        }

        if (String.Equals(args.purchasedProduct.definition.id, minimumCoins, StringComparison.Ordinal))
        {
            Debug.Log("Player just bought 300 Coins!");

          //..Add coins down here..
          
        }
        else
        {
            Debug.Log("Purchased has failed. Please try again.");
        }

        if (String.Equals(args.purchasedProduct.definition.id, mediumCoins, StringComparison.Ordinal))
        {
            Debug.Log("Player just bought 640 Coins!");

            //..Add coins down here..

        }
        if (String.Equals(args.purchasedProduct.definition.id, largeCoins, StringComparison.Ordinal))
        {
            Debug.Log("Player just bought 1,150 Coins!");

            //..Add coins down here..

        }

        else
        {
            Debug.Log("Purchased has failed. Please try again.");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void BuyRemoveAllAds()
    {
        BuyProductID(removeAllAds);
    }

    public void BuyMinimumCoins()
    {
        BuyProductID(minimumCoins);
    }

    public void BuyMediumCoins()
    {
        BuyProductID(mediumCoins);
    }

    public void BuyLargeCoins()
    {
        BuyProductID(largeCoins);
    }

    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);

            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }


    //  
    // --- IStoreListener
    //

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }


}
