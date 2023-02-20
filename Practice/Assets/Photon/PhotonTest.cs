using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonTest : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _prefab;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }

    void OnGUI()
    {
        // ���O�C����Ԃ���ʂɏo��
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    public override void OnConnectedToMaster()
    {
        // "room"�Ƃ������O�̃��[���ɎQ������(���[�����Ȃ���΍쐬���Ă���Q������)
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
        Debug.Log("�R�l�N�g");
    }

    public override void OnJoinedRoom()
    {
        // �L�����N�^�[�𐶐�����
        GameObject go = PhotonNetwork.Instantiate("Monster", Vector3.zero, Quaternion.identity, 0);
        Debug.Log(go.name);

        // ��������������ł���悤�ɃX�N���v�g��L������
        MonsterScript monsterScript = go.GetComponent<MonsterScript>();
        monsterScript.enabled = true;
    }
}
