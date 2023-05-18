using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadFromDrive : MonoBehaviour
{
    [SerializeField]
    private string _assetName = default;

    [SerializeField]
    private Image _image = default;

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(DownloadAsset());
    }

    [System.Obsolete]
    IEnumerator DownloadAsset()
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle
            ("https://drive.google.com/uc?export=download&id=12X3MlArdcZGZOOFWz6VWmCPEU1q2km0Z"))
        { 
        
        yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                var sprite = bundle.LoadAsset<Sprite>(_assetName);
                _image.sprite = sprite;
            }
        }
    }
}
