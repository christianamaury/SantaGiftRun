using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
    private string sharedMessage;

    public void ClickShareButton()
    {
        sharedMessage = "WoW!! Did I just scored" + PlayerPrefs.GetInt("BestScore", 0).ToString() + "points in Santa Gift Run";

        StartCoroutine(TakeSSAndShare());
    }


    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        //..In order to avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Santa Gift Run!").SetText(sharedMessage).Share();

    }

}
