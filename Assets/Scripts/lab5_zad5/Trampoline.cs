using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player hit trampoline");
            var player = collision.gameObject.GetComponent<MoveAndRotateWithCharacterController>();
            player.Jump(3);
        }
    }
}
