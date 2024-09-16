using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawRigControls : MonoBehaviour
{

    [SerializeField] private float _vertical;
    [SerializeField] private float _horizontal;

    [SerializeField] private float _minRotationY = 0;
    [SerializeField] private float _maxRotationY = 90;

    [SerializeField] private float _destinationY = 90;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private bool _rotating;
    [SerializeField] private bool _goingUp;


    [SerializeField] private Quaternion _currentRot;

    [SerializeField] private float _newRotY;


    [SerializeField] private Transform _pawRotTargetMax;
    [SerializeField] private Transform _pawRotTargetMin;

    [SerializeField] private float _timeCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");


        if (_horizontal > 0f)
        {

            _rotating = true;
            _goingUp = true;
        }
        else
        {
           if(_horizontal < 0f)
            {
                _rotating = true;
                _goingUp = false;
            }
            else
            {
                _rotating = false;
                _goingUp = false;
                _timeCount = 0;
                _currentRot = transform.localRotation;
            }
        }


       

        if (_rotating)
        {
            if (_goingUp)
            {
            
                transform.localRotation = Quaternion.Lerp(_currentRot, _pawRotTargetMax.localRotation, _timeCount * _rotationSpeed);

            }
            else
            {
           
                transform.localRotation = Quaternion.Lerp(_currentRot, _pawRotTargetMin.localRotation, _timeCount * _rotationSpeed);
            }



            _timeCount = _timeCount + Time.deltaTime;
        }

    }
}
