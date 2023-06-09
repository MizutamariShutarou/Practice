using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromFileExample : MonoBehaviour
{
    [SerializeField, Tooltip("AssetBundleに格納されているスプライトを張り付けるImage")] 
    private Image _image = default
        ;
    private void Start()
    {
        // AssetBundleのメタ情報をロード
        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "myassetBundle"));

        if (assetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        // テクスチャをメモリにロード
        var sprite = assetBundle.LoadAsset<Sprite>("AssetBundleSample");

        _image.sprite = sprite;

        // AssetBundleのメタ情報をアンロード
        assetBundle.Unload(false);
    }
}