using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangePivot : MonoBehaviour
{
    [SerializeField] List<GameObject> Pivots = new List<GameObject>();
    [SerializeField] float MaxDistance;
    [SerializeField] bool SpacePressed;
    void Start()
    {
        GameObject[] FoundPivots = GameObject.FindGameObjectsWithTag("Pivot");
        Pivots.AddRange(FoundPivots);

    }

    void Update()
    {
        CheckDistance();

        if (Input.GetKeyDown(KeyCode.Space) && !SpacePressed)
        {
            SwitchPivot();
            SpacePressed = true;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            HingeJoint2D MyJoint = GetComponent<HingeJoint2D>();
            MyJoint.connectedBody = null;
            SpacePressed = false;
        }

    }


    void CheckDistance()
    {
        MaxDistance = 0;

        for (int i = 0; i < Pivots.Count; i++)
        {
            float Distance = Vector2.Distance(transform.position, Pivots[i].transform.position);

            if (Distance > MaxDistance)
            {
                MaxDistance = Distance;
            }
        }
    }

    void SwitchPivot()
    {
        for (int i = 0; i < Pivots.Count; i++)
        {
            float Distance = Vector2.Distance(transform.position, Pivots[i].transform.position);

            if (MaxDistance == Distance)
            {
                HingeJoint2D MyJoint = GetComponent<HingeJoint2D>();
                Rigidbody2D Newtarget = Pivots[i].GetComponent<Rigidbody2D>();

                MyJoint.connectedBody = Newtarget;

            }
        }
    }
}
