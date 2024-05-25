using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string _versionName = "1";

    [SerializeField]
    private GameObject _userNamePanel, _menuPanel, _startButton, _settingsPanel;

    [SerializeField]
    private TMP_InputField _userNameInput, _createGameInput, _joinGameInput, _sensX, _sensY;
    public static float sensX, sensY;
    
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(_versionName);
    }

    private void Start()
    {
        _userNamePanel.SetActive(true);
        sensX = 300;
        sensY = 300;
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    
    public void ChangeUserName()
    {
        if(_userNameInput.text.Length >= 5)
        {
            _startButton.SetActive(true);
        }
        else
        {
            _startButton.SetActive(false);
        }
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        sensX = float.Parse(_sensX.text);
        sensY = float.Parse(_sensY.text);
        Debug.Log(sensX);
    }

    public void SetUserNameToGame()
    {
        _userNamePanel.SetActive(false);
        PhotonNetwork.playerName = _userNameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(_createGameInput.text, new RoomOptions(){ maxPlayers = 10 }, null);
    }

    public void JoinGame()
    {
        PhotonNetwork.JoinOrCreateRoom(_joinGameInput.text, new RoomOptions(){maxPlayers=10}, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main Game");
    }
}
