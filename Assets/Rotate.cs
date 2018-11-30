using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private Vector3 mouse_pos;
    public Transform target;
    public Camera mainCamera;
    private Vector3 object_pos;
    private float angle;
    #region ROTATE
    private float _sensitivity = 0.5f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    private bool _isRotating;

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetMouseButton(0)) {
            mouse_pos = Input.mousePosition;
            mouse_pos.y = 0;
            object_pos = mainCamera.WorldToScreenPoint(target.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.z = mouse_pos.z - object_pos.z;
            angle = Mathf.Atan2(mouse_pos.z, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(target.rotation.x, target.rotation.y + angle, target.rotation.z);
        }
        */
        if (_isRotating) {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);
            // apply rotation
            //_rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            _rotation.z = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity; // rotate
            gameObject.transform.Rotate(_rotation); // store new mouse position
            _mouseReference = Input.mousePosition;
            // rotate
            //transform.Rotate(_rotation);
            transform.eulerAngles += _rotation;
            // store mouse
        }
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse position
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }
}