using UnityEngine;
using Unity.Cinemachine;


public class WinScript : MonoBehaviour
{

    [SerializeField] Transform vCam;
    [SerializeField] Transform winPosition;
    [SerializeField] bool Attract;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("AtractionField"))
        {
            vCam.GetComponent<CinemachineLockX>().enabled = true;
            Attract = true;
        }
    }

    void Update()
    {
        if (Attract)
        {
            transform.position = Vector3.MoveTowards(transform.position, winPosition.position + Vector3.right * 2, 5 * Time.deltaTime);
        }
    }
}
