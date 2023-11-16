using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveOnCurve : MonoBehaviour
{
    [SerializeField] private Curve curve;
    [SerializeField] private float interpolater = 0.5f;
    [SerializeField] private float speed;
    [SerializeField] private int point;
    
    void Update()
    {
        if(point >= 0 && point <= curve.Points.Count)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                interpolater += speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                interpolater -= speed;
            }
        }
        

        if (interpolater > 1)
        {
            if (point < curve.Points.Count - 2 )
            {
                interpolater = 0;
                point++;
            }
            else
                interpolater = 1;
        }
        if (interpolater < 0)
        {
            if (point > 0)
            {
                interpolater = 1;
                point--;
            }
            else
                interpolater = 0;

        }



        if (curve.Points != null)
        {
            for (int i = 0; i < curve.Points.Count - 1; i++)
            {
                if(i == point)
                transform.position = Vector3.Slerp(curve.Points[i], curve.Points[i + 1], interpolater);

            }
        }


    }
}
