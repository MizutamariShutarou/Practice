using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonTest : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }

    void OnGUI()
    {
        // ログイン状態を画面に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    public override void OnConnectedToMaster()
    {
        // "room"という名前のルームに参加する(ルームがなければ作成してから参加する)
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // キャラクターを生成する
        GameObject go = PhotonNetwork.Instantiate("gameObject", Vector3.zero, Quaternion.identity, 0);

        // 自分だけが操作できるようにスクリプトを有効する
        MonsterScript monsterScript = go.GetComponent<MonsterScript>();
        monsterScript.enabled = true;
    }
}
