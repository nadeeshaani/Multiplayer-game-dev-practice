using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject loading;
    [Header("LOBBY")]
    [SerializeField] private GameObject lobby;
    [SerializeField] private TMP_InputField createRoomField;
    [SerializeField] private TMP_InputField joinRoomField;

    [Header("PLAYER")]
    [SerializeField] private SpawnPlayer spawnPlayer;


    //[SerializeField]

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        loading.SetActive(true);
        lobby.SetActive(false);
    }

    internal void ShowLobby()
    {
        loading.SetActive(false);
        lobby.SetActive(true);
    }

    public void CreateRoom(){
        Server.Instance.CreateRoom(createRoomField.text);
    }

    public void JoinRoom()
    {
        Server.Instance.JoinRoom(joinRoomField.text);
    }

    internal void OnJoinedRoom()
    {
        lobby.SetActive(false);

        spawnPlayer.Spawn();
    }



    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


}
