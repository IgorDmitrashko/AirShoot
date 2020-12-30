using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Ball") Destroy(gameObject);
    }
}
