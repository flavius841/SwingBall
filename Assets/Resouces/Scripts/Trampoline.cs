using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float launchForce = 15f;
    [SerializeField] AudioSource bounceSound;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        bounceSound.Play();
        
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 preCollisionRelativeVelocity = collision.relativeVelocity;
        Vector2 surfaceNormal = collision.GetContact(0).normal;


        if (rb != null)
        {
            float parentZRotation = transform.parent.eulerAngles.z;
            
            if (Mathf.Approximately(parentZRotation, 0f) || Mathf.Approximately(parentZRotation, 360f))
            {
                rb.linearVelocity = new Vector2(preCollisionRelativeVelocity.x, 0f);
                
            }

            else
            {
                rb.linearVelocity = new Vector2(0f, preCollisionRelativeVelocity.y);
                Debug.Log(surfaceNormal+ "surfacenormal");
            }

            rb.AddForce(-surfaceNormal * launchForce, ForceMode2D.Impulse);

            Debug.Log(preCollisionRelativeVelocity+"precolisionvelocity");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            if (rb.linearVelocity.magnitude < 0.1f)
            {
                Debug.Log("Object is stuck on the trampoline. Applying force to launch it.");
                collision.gameObject.transform.position += new Vector3(2f, 0f, 0);
                rb.linearVelocity = Vector2.right * launchForce;
            }
        }
    }
}