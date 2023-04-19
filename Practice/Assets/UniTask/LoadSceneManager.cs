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
    /// �V�[����ǂݍ���
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name)
    {
        // �R���[�`���Ń��[�h��ʂ����s
        StartCoroutine(LoadSceneExecute(name));
    }
    IEnumerator LoadSceneExecute(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        asyncLoad.allowSceneActivation = false;
        // �X���C�_�[�̒l�X�V�ƃ��[�h��ʂ̕\��
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
                // ���[�h�o�[��100%�ɂȂ��Ă�1�b�����\���ێ�
                break;
            }
        }
        // ���[�h��ʂ̔�\��
        _canvas.SetActive(false);
    }
}
