using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Ball")) Destroy(gameObject);
    }
}
