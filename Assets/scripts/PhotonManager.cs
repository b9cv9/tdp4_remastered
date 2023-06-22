using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections.Generic;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string region;
    [SerializeField] InputField RoomName;
    [SerializeField] Listitem itemPrefab;
    [SerializeField] Transform content;


    List<RoomInfo> allRoomsInfo = new List<RoomInfo>();
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Вы подключены к: " + PhotonNetwork.CloudRegion);
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Вы отключены от сервера!");
    }

    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 8;
        PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
        PhotonNetwork.LoadLevel("game_scene");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Создана комната, имя комнаты: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Не удалось создать комнату!");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            for(int i = 0; i < allRoomsInfo.Count; i ++)
            {
                if (allRoomsInfo[i].masterClientId == info.masterClientId)
                {
                    return;
                }
            }
            Listitem listitem = Instantiate(itemPrefab, content);
            if (listitem != null)
            {
                listitem.SetInfo(info);
                allRoomsInfo.Add(info);
            }
            
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("game_scene");
    }

    public void JoinRandRoomButton()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinButton()
    {
        PhotonNetwork.JoinRoom(RoomName.text);
    }

    public void LeaveButton()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
