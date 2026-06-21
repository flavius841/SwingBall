using UnityEngine;
using Unity.Cinemachine;

public class Loose : MonoBehaviour
{
    [SerializeField] CinemachineCamera vCam;
    [SerializeField] Transform SpawnPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            transform.position = SpawnPoint.position;
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
}
