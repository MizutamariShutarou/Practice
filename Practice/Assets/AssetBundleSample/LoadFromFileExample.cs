using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromFileExample : MonoBehaviour
{
    [SerializeField, Tooltip("AssetBundle�Ɋi�[����Ă���X�v���C�g�𒣂�t����Image")] 
    private Image _image = default
        ;
    private void Start()
    {
        // AssetBundle�̃��^�������[�h
        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "myassetBundle"));

        if (assetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        // �e�N�X�`�����������Ƀ��[�h
        var sprite = assetBundle.LoadAsset<Sprite>("AssetBundleSample");

        _image.sprite = sprite;

        // AssetBundle�̃��^�����A�����[�h
        assetBundle.Unload(false);
    }
}