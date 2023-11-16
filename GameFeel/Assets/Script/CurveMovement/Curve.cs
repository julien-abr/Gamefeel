using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Curve : MonoBehaviour
{
    
    [SerializeField] private Transform startPoint, centerPoint, endPoint;
    [SerializeField] private int count = 15;
    [SerializeField] private List<Vector3> points;

   // public int Count { get => count;}
    public List<Vector3> Points { get => points;}

    private void OnDrawGizmos()
    {
        foreach (var point in EvaluateSlerpPoints(startPoint.position, endPoint.position, centerPoint.position, count))
        {
            Gizmos.DrawSphere(point, 0.1f);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(centerPoint.position, 0.2f);
    }
    private void Start()
    {
        foreach (var point in EvaluateSlerpPoints(startPoint.position, endPoint.position, centerPoint.position, count))
        {
            points.Add(point);
        }
    }
    private void Update()
    {
        
    }
    public IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center, int count = 10)
    {
        var startRelativeCenter = start - center;
        var endRelativeCenter = end - center;

        var f = 1f / count;

        for (var i = 0f; i < 1 + f; i += f)
        {
            
            yield return Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center;
        }


    }

}
