using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] LoadSceneManager _loadSceneManager;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �V�[����ǂݍ���
            _loadSceneManager.LoadScene("GameScene");
        }
    }
}
