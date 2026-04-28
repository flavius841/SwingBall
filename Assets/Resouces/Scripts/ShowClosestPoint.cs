using UnityEngine;
using System.Collections.Generic;

public class ShowClosestPoint : MonoBehaviour
{
    [SerializeField] List<GameObject> Pivots = new List<GameObject>();
    [SerializeField] float MinDistance;
    void Start()
    {
        GameObject[] FoundPivots = GameObject.FindGameObjectsWithTag("Pivot");
        Pivots.AddRange(FoundPivots);
    }

    void Update()
    {
        CheckDistance();
        SwitchPivot();
    }

    void CheckDistance()
    {
        MinDistance = Mathf.Infinity;

        for (int i = 0; i < Pivots.Count; i++)
        {
            float Distance = Vector2.Distance(transform.position, Pivots[i].transform.position);

            if (Distance < MinDistance)
            {
                MinDistance = Distance;
            }
        }
    }

    void SwitchPivot()
    {
        for (int i = 0; i < Pivots.Count; i++)
        {
            float Distance = Vector2.Distance(transform.position, Pivots[i].transform.position);

            if (MinDistance == Distance)
            {
                Pivots[i].transform.GetChild(2).gameObject.SetActive(true);
            }

            else
            {
                Pivots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
}
