using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefabs, _sceneCamera;

    private void Start()
    {
        PhotonNetwork.Instantiate(_playerPrefabs.name, transform.position, Quaternion.identity,0);
        _sceneCamera.SetActive(false);
    }
}
