

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDControl : MonoBehaviour
{

    private Camera mainCamera;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private Vector3 dragOrigin;
    [SerializeField] float mapMinX, mapMinY, mapMaxX, mapMaxY;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        ZoomCamera();

        PanCamera();
    }

    public void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            mainCamera.orthographicSize += zoomStep * Time.deltaTime;

            if (mainCamera.orthographicSize > maxCamSize)
            {
                mainCamera.orthographicSize = maxCamSize; // Max size
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            mainCamera.orthographicSize -= zoomStep * Time.deltaTime;
            if (mainCamera.orthographicSize < minCamSize)
            {
                mainCamera.orthographicSize = minCamSize; // Min size
            }
        }
    }


    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mainCamera.transform.position += difference;
            mainCamera.transform.position = ClampCamera(mainCamera.transform.position);
        }

    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = mainCamera.orthographicSize;
        float camWidth = mainCamera.orthographicSize * mainCamera.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

}



