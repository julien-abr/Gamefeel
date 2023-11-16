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

     private float leftSlideTime;
     private float rightSlideTime;
    [SerializeField] private float initSlideTime = 0.2f;
    [SerializeField] private float friction = 5f;

    private void OnEnable()
    {
        point = 10;
    }
    void Update()
    {
        if (point >= 0 && point <= curve.Points.Count)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                interpolater += speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            {
                interpolater -= speed;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                rightSlideTime = initSlideTime;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Q))
            {
                leftSlideTime = initSlideTime;
            }
        }

        if(rightSlideTime >= 0)
        {
            rightSlideTime -= Time.deltaTime;

            for (float i = 0.9f; i >= 0; i -= 0.1f)
            {

                if (rightSlideTime >= initSlideTime * i)
                {
                    interpolater += speed * i / friction;                  
                }
            }
            
        }
        if (leftSlideTime >= 0)
        {
            leftSlideTime -= Time.deltaTime;

            for(float i = 0.9f; i >= 0; i-= 0.1f)
            {
                
                if(leftSlideTime >= initSlideTime * i)
                {
                    interpolater -= speed * i / friction;               
                }
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
