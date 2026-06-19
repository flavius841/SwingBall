using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float launchForce = 15f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding has a Rigidbody2D (like the player)
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Optional: Check if the player is actually falling down onto it
            if (rb.linearVelocity.y <= 0.1f)
            {
                // Reset the vertical velocity so the launch force is always consistent
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

                // Apply the upward force
                rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}