using UnityEngine;

public class IsMine : Photon.MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _camera;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private GameObject _playerModel;

    private void Start()
    {
        if(!_photonView.isMine)
        {
            _playerController.enabled = false;
            _camera.SetActive(false);
            _playerModel.SetActive(true);
        }
    }
}
