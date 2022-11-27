using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndZoom : MonoBehaviour
{
    private const float MouseZoomSpeed = 15.0f;
    private const float TouchZoomSpeed = 0.1f;
    private const float ZoomMinBound = 0.1f;
    private const float ZoomMaxBound = 179.9f;
    private Camera m_Cam;

    // Use this for initialization
    private void Start()
    {
        m_Cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {

                // get current touch positions
                var tZero = Input.GetTouch(0);
                var tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                var tZeroPrevious = tZero.position - tZero.deltaPosition;
                var tOnePrevious = tOne.position - tOne.deltaPosition;

                var oldTouchDistance = Vector2.Distance (tZeroPrevious, tOnePrevious);
                var currentTouchDistance = Vector2.Distance (tZero.position, tOne.position);

                // get offset value
                var deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom (deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, MouseZoomSpeed);
        }
        
        if(m_Cam.fieldOfView < ZoomMinBound)
            m_Cam.fieldOfView = 0.1f;
        else
            if(m_Cam.fieldOfView > ZoomMaxBound )
                m_Cam.fieldOfView = 179.9f;
    }

    private void Zoom(float deltaMagnitudeDiff, float speed)
    {
        var fieldOfView = m_Cam.fieldOfView;
        fieldOfView += deltaMagnitudeDiff * speed;
        m_Cam.fieldOfView = fieldOfView;
        // set min and max value of Clamp function upon your requirement
        m_Cam.fieldOfView = Mathf.Clamp(fieldOfView, ZoomMinBound, ZoomMaxBound);
    }
}