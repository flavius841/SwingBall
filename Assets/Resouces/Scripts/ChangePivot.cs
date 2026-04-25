using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangePivot : MonoBehaviour
{
    [SerializeField] List<GameObject> Pivots = new List<GameObject>();
    [SerializeField] float MinDistance;
    [SerializeField] bool SpacePressed;
    [SerializeField] int precision = 40;
    [SerializeField] float wobbleIntensity = 2f;
    [SerializeField] AnimationCurve wobbleCurve;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float animationSpeed = 5f;
    private Transform currentTarget;
    private bool isAnimating = false;

    void Start()
    {
        GameObject[] FoundPivots = GameObject.FindGameObjectsWithTag("Pivot");
        Pivots.AddRange(FoundPivots);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;

    }

    void Update()
    {
        CheckDistance();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentTarget = SwitchPivot().transform;
            SpacePressed = true;
            StartCoroutine(AnimateRope(currentTarget.position));
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            HingeJoint2D MyJoint = GetComponent<HingeJoint2D>();
            MyJoint.connectedBody = null;
            lineRenderer.enabled = false;
            SpacePressed = false;
            currentTarget = null;
            isAnimating = false;
        }

        if (SpacePressed && !isAnimating && currentTarget != null)
        {
            DrawRopeProcedural(currentTarget.position, 1f);
        }
    }


    void CheckDistance()
    {
        MinDistance = 100000000;

        for (int i = 0; i < Pivots.Count; i++)
        {
            float Distance = Vector2.Distance(transform.position, Pivots[i].transform.position);

            if (Distance < MinDistance)
            {
                MinDistance = Distance;
            }
        }
    }

    GameObject SwitchPivot()
    {
        for (int i = 0; i < Pivots.Count; i++)
        {
            float Distance = Vector2.Distance(transform.position, Pivots[i].transform.position);

            if (MinDistance == Distance)
            {
                return Pivots[i];
            }
        }

        return Pivots[0];
    }

    IEnumerator AnimateRope(Vector2 targetPos)
    {
        isAnimating = true;
        lineRenderer.enabled = true;
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime * animationSpeed;
            DrawRopeProcedural(targetPos, progress);
            yield return null;
        }

        HingeJoint2D MyJoint = GetComponent<HingeJoint2D>();
        MyJoint.connectedBody = currentTarget.GetComponent<Rigidbody2D>();
        isAnimating = false;
    }

    void DrawRopeProcedural(Vector2 targetPos, float progress)
    {
        lineRenderer.positionCount = precision;
        Vector2 startPos = transform.position;
        Vector2 currentEndPoint = Vector2.Lerp(startPos, targetPos, progress);

        Vector2 dir = (targetPos - startPos).normalized;
        Vector2 perpendicular = new Vector2(-dir.y, dir.x);

        for (int i = 0; i < precision; i++)
        {
            float t = (float)i / (precision - 1);

            Vector3 pos = Vector2.Lerp(startPos, currentEndPoint, t);

            float wave = Mathf.Sin(t * Mathf.PI * 6) * wobbleIntensity * (1 - progress);

            pos += (Vector3)perpendicular * wave * wobbleCurve.Evaluate(t);

            lineRenderer.SetPosition(i, pos);
        }
    }
}

