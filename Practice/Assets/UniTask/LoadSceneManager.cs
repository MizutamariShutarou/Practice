using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    [SerializeField] Image _image;
    /// <summary>
    /// シーンを読み込む
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name)
    {
        // コルーチンでロード画面を実行
        StartCoroutine(LoadSceneExecute(name));
    }
    IEnumerator LoadSceneExecute(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false;
        // スライダーの値更新とロード画面の表示
        _image.fillAmount = 0f;
        _canvas.SetActive(true);
        while (true)
        {
            yield return null;
            _image.fillAmount = asyncLoad.progress;
            Debug.Log(asyncLoad.progress);
            if (asyncLoad.progress >= 0.9f)
            {
                _image.fillAmount = 1f;
                yield return new WaitForSeconds(4f);
                asyncLoad.allowSceneActivation = true;
                // ロードバーが100%になっても1秒だけ表示維持
                break;
            }
        }
        // ロード画面の非表示
        _canvas.SetActive(false);
    }
}
