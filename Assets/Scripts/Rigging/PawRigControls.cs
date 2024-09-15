using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawRigControls : MonoBehaviour
{

    [SerializeField] private float _vertical;
    [SerializeField] private float _horizontal;

    [SerializeField] private float _minRotationY = 0;
    [SerializeField] private float _maxRotationY = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        
    }
}
