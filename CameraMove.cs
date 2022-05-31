﻿using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Camera")]
    public float speed = 10.0f;

    Vector3 camPos;

    [Header("Zoom")]
    public float minZoom = 5.0f;
    public float maxZoom = 250.0f;

    float zoom;

    private void Start()
    {
        camPos.z = -10;
    }

    void Update()
    {
        if (GameController.instance.state == 2) GetComponent<Camera>().backgroundColor = new Color(25/255f, 25 / 255f, 25 / 255f);
       Move();

        transform.position = camPos;
        camPos = transform.position;

        Zoom();

        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        GetComponent<Camera>().orthographicSize = zoom;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            camPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            camPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            camPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            camPos.x += speed * Time.deltaTime;
        }
    }

    void Zoom()
    {
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            zoom -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            zoom += speed * Time.deltaTime;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            zoom -= speed * Time.deltaTime * 10f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += speed * Time.deltaTime * 10f;
        }
    }

    

}