using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingTargetCube : MonoBehaviour
{
    [SerializeField] private Transform _targetCube;
    [SerializeField] private Transform _initialTargetRotation;

    
    // Start is called before the first frame update
    void Start()
    {
        _targetCube.localRotation = _initialTargetRotation.localRotation;
         _targetCube.localPosition = _initialTargetRotation.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

  
}
