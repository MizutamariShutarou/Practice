using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxMVPSample
{
    /// <summary>
    /// �X�R�A�̕\��(�e�L�X�g�̏������Ɠn���ꂽ�l�ɏ��������鏈�����L��)
    /// </summary>
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] Text _scoreText;

        public void Initialize()
        {
            _scoreText.text = "";
        }

        public void ShowScoreText(int score)
        {
            _scoreText.text = score.ToString(); 
        }
    }
}

