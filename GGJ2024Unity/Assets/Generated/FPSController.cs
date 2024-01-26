using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Text ammoText;
    public int startingAmmo = 12;
    private int currentAmmo;

    private Camera playerCamera;
    private Vector2 lookInput;
    private bool isFiring;

    void Start()
    {
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = startingAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        if (currentAmmo <= 0)
        {
            isFiring = false;
            return;
        }

        lookInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        transform.Rotate(Vector3.up * (lookInput.x * mouseSensitivity * Time.deltaTime));
        playerCamera.transform.Rotate(Vector3.right * (lookInput.y * mouseSensitivity * Time.deltaTime));

        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
        }

        if (isFiring)
        {
            Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * 100, Color.red);
            currentAmmo--;
            UpdateAmmoText();
        }
        else
        {
            isFiring = false;
        }
    }

    void UpdateAmmoText()
    {
        ammoText.text = $"Ammo: {currentAmmo}";
    }
}