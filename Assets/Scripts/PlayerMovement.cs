using UnityEngine;
using Unity.Netcode;
public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    private void Update()
    {
         Debug.Log("Update");
         if (!IsOwner) return;

         float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");
         
        Vector3 move = new Vector3(h, 0, v);
        
        controller.Move(move * speed * Time.deltaTime);
    }
}
