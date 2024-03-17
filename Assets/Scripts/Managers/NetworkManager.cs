using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField nickNameInputField;

    public GameObject disconnectPannel;
    public GameObject respawnPannel;

    [SerializeField] private Player playerObj;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = nickNameInputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        disconnectPannel.SetActive(true);
        respawnPannel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }
    public override void OnJoinedRoom()
    {
        disconnectPannel.SetActive(false);
        Spawn();
    }

    public void Spawn()
    {
        PhotonNetwork.Instantiate(playerObj.name, Vector3.zero, Quaternion.identity);
    }
}
