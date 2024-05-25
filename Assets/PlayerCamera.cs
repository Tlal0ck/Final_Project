using UnityEditor;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // ���������� ��� ���������������� �� ����. �� �����
    private float sensX = MenuController.sensX;
    private float sensY = MenuController.sensY;
    // ���������� ��� �����������, ������ � ���� ������ ����� ���������
    public Transform orientation, player;
    // ���������� �������� ��������
    float xRotation;
    float yRotation;

    private void Start()
    {
        // ��������� ������ � ������ ��� ���������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // ���������� ���������� �����.
        // �� �������� ��� ������������� �� ������ � ��������� �� ����������������   
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        // �������� �������� ���� � ������������ �������� �� -90 �� 90
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // ������������� �������� ��� ������ �������� ����������� ��� ������ Quaternion
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
