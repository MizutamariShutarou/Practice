using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxMVPSample
{
    /// <summary>
    /// �����̃f�[�^��ύX�B�����ڂ̕ύX�ɂ͊֗^���Ȃ��B
    /// </summary>
    public class ScoreModel
    {
        /// <summary>
        /// �Ď��̑Ώۂ�ݒ�
        /// </summary>
        public ReactiveProperty<int> CurrentScore { get; private set; }

        /// <summary>
        /// MonoBehaviour���p�����Ă��Ȃ����߃R���X�g���N�^�̐錾���ł���
        /// </summary>
        public ScoreModel(int initScore)
        {
            CurrentScore = new ReactiveProperty<int>(initScore);
        }

        public void AddScore(int addScore)
        {
            // .Value��ReactiveProperty<int>�^�̒l�ɃA�N�Z�X�ł���(����A�Q�Ƃ��\)
            CurrentScore.Value += addScore;
        }

        public void ResetScore()
        {
            CurrentScore.Value = 0;
        }
    }
}

