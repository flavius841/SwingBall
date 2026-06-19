using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float launchForce = 15f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding has a Rigidbody2D (like the player)
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 preCollisionRelativeVelocity = collision.relativeVelocity;
        Vector2 surfaceNormal = collision.GetContact(0).normal;


        if (rb != null)
        {
            Debug.Log(surfaceNormal);
            
            // Optional: Check if the player is actually falling down onto it
            if (rb.linearVelocity.y <= 0.1f)
            {
                // Reset the vertical velocity so the launch force is always consistent
                rb.linearVelocity = new Vector2(preCollisionRelativeVelocity.x, 0f);

                // Apply the upward force
                rb.AddForce(-surfaceNormal * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}