using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromFileExample : MonoBehaviour
{
    [SerializeField] private Image image;
    private void Start()
    {
        // AssetBundle�̃��^���̃��[�h
        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "samplefolder/sample"));
        if (assetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        // �e�N�X�`�����������Ƀ��[�h
        var sprite = assetBundle.LoadAsset<Sprite>("assetbundle");

        image.sprite = sprite;

        // AssetBundle�̃��^�����A�����[�h
        assetBundle.Unload(false);
    }
}