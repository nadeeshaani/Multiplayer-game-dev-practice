using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Server : MonoBehaviourPunCallbacks
{


    #region VARIABLES

    public static Server Instance { get; private set; }

    #endregion


    #region UNITY CALLBACKS
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        PhotonNetwork.ConnectUsingSettings();
    }


    #endregion


    #region SERVER CALLBACKS
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    
    public override void OnJoinedLobby()
    {
        GameManager.Instance.ShowLobby();
    }

    public override void OnJoinedRoom()
    {
        GameManager.Instance.OnJoinedRoom();
    }

    #endregion

    #region LOBBY CALLBACKS


    #endregion

    #region INSTANTIATE
    internal void InstantiateGameObject(string goName, Vector3 pos, Quaternion rotation)
    {
        PhotonNetwork.Instantiate(goName, pos, rotation);
    }


    #endregion

    internal void CreateRoom(string roomID)
    {
        PhotonNetwork.CreateRoom(roomID);
    }

    internal void JoinRoom(string roomID)
    {
        PhotonNetwork.JoinRoom(roomID);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
