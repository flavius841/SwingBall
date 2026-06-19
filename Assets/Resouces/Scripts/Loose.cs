using UnityEngine;
using Unity.Cinemachine;

public class Loose : MonoBehaviour
{
    [SerializeField] CinemachineCamera vCam;
    public Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            transform.position = new Vector3(0, 24, 0);
            vCam.Target.TrackingTarget = transform;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("CameraLimit"))
        {
            vCam.Target.TrackingTarget = null;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // void Update()
    // {
    //     Debug.Log("Velocity: " + rb.linearVelocity.x);
    // }
}
