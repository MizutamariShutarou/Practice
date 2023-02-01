using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxMVPSample
{
    /// <summary>
    /// 内部のデータを変更。見た目の変更には関与しない。
    /// </summary>
    public class ScoreModel
    {
        /// <summary>
        /// 監視の対象を設定
        /// </summary>
        public ReactiveProperty<int> CurrentScore { get; private set; }

        /// <summary>
        /// MonoBehaviourを継承していないためコンストラクタの宣言ができる
        /// </summary>
        public ScoreModel(int initScore)
        {
            CurrentScore = new ReactiveProperty<int>(initScore);
        }

        public void AddScore(int addScore)
        {
            // .ValueでReactiveProperty<int>型の値にアクセスできる(代入、参照が可能)
            CurrentScore.Value += addScore;
        }

        public void ResetScore()
        {
            CurrentScore.Value = 0;
        }
    }
}

