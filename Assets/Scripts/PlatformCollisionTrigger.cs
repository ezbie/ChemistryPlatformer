using UnityEngine;

public class PlatformCollisionTrigger : MonoBehaviour
{
    private BoxCollider2D PlayerCollider;
    [SerializeField] private BoxCollider2D PlatformCollider; // This refers to the collider in which the player can stand
    [SerializeField] private BoxCollider2D PlatformTrigger; // This refers to second box collider
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();

        // Prevent the two Platform colliders from colliding
        Physics2D.IgnoreCollision(PlatformCollider, PlatformTrigger, true); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(PlayerCollider, PlayerCollider, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(PlayerCollider, PlayerCollider, false);
        }
            

    }
}
