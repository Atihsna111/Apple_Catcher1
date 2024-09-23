using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController PlayerController;

    void Start()
    {
        PlayerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerController.Dead();
        }
    }
}
