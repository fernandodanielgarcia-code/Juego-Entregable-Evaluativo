using UnityEngine;
using Unity.Netcode;
public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    public float gravity = -9f;

    private CharacterController controller;
    private float verticalVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        
        if (!IsOwner) return;

        if (GameManager.instance != null && GameManager.instance.gameEnded.Value)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        controller.Move(move * speed * Time.deltaTime);

        

        if (controller.isGrounded && verticalVelocity <0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
}
