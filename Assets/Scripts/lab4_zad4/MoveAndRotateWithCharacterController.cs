using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateWithCharacterController : MonoBehaviour
{
    public GameObject camera;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 10.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float sensitivity = 200f;
    private float cameraRot;

    private void Start()
    {
        // zak³adamy, ¿e komponent CharacterController jest ju¿ podpiêty pod obiekt
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized;
        controller.Move(move * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        cameraRot -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        cameraRot = Mathf.Clamp(cameraRot, -5f, 45f);

        transform.Rotate(Vector3.up * mouseXMove);
        camera.transform.eulerAngles = new Vector3(cameraRot, transform.eulerAngles.y, 0f);
    }
    public void Jump(float multilier = 1f)
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue) * multilier;
    }
}