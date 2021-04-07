using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    public Draggable _lastDragged;
    private Rigidbody2D rb;
    private Vector2 direction;
    [SerializeField] float speed = 0.02f;


    void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        //Debug.Log(controllers);
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void FixedUpdate()
    {

        if (_isDragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);


        if (_isDragActive)
        {
            Drag();
        }
        else if(!_isDragActive)
        {
            LayerMask tamaMask = LayerMask.GetMask("Tama");
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero, tamaMask);

            if (hit.collider != null)
            {
                //Debug.Log("You find me");
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                    //Debug.Log("You drag me");
                }
            }

        }
    }

    void InitDrag()
    {
        _isDragActive = true;
    }

    void Drag()
    {
        direction = new Vector2(_worldPosition.x, _worldPosition.y);
        rb = _lastDragged.transform.gameObject.GetComponent<Rigidbody2D>();
        rb.MovePosition((Vector2)_lastDragged.transform.position + (direction * speed * Time.deltaTime));
        
        
    }

    void Drop()
    {
        _isDragActive = false;
    }


}
