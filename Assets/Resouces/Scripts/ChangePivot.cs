using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangePivot : MonoBehaviour
{
    [SerializeField] List<GameObject> Pivots = new List<GameObject>();
    [SerializeField] float Distance;
    [SerializeField] float MaxDistance;
    void Start()
    {
        GameObject[] FoundPivots = GameObject.FindGameObjectsWithTag("Pivot");
        Pivots.AddRange(FoundPivots);

    }

    void Update()
    {


    }
}
