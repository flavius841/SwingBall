using UnityEngine;
using Unity.Cinemachine;

public class Loose : MonoBehaviour
{
    [SerializeField] CinemachineCamera vCam;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            transform.position = new Vector3(0, 9, 0);
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
