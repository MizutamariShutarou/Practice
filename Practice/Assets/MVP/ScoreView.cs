using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxMVPSample
{
    /// <summary>
    /// スコアの表示(テキストの初期化と渡された値に書き換える処理を記入)
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

