using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePurchases : MonoBehaviour
{
    public static RestorePurchases Instance { get; set; }

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_IOS
        gameObject.SetActive(true);
        #endif

        #if UNITY_ANDROID
        gameObject.SetActive(false);
        #endif
    }

    public void ClickRestorePurchaseButton()
    {
        IAPurchase.Instance.RestorePurchases();
    }
}
