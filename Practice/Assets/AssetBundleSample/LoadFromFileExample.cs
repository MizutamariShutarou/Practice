using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromFileExample : MonoBehaviour
{
    [SerializeField] private Image image;
    private void Start()
    {
        // AssetBundleのメタ情報のロード
        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "samplefolder/sample"));
        if (assetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        // テクスチャをメモリにロード
        var sprite = assetBundle.LoadAsset<Sprite>("assetbundle");

        image.sprite = sprite;

        // AssetBundleのメタ情報をアンロード
        assetBundle.Unload(false);
    }
}