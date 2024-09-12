using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

[RequireComponent(typeof(MeshFilter))]
public class ClayPotTransformation : MonoBehaviour
{

    public float Progress
    {
        get
        {
            return transformV;
        }
        set
        {
            transformV = Mathf.Clamp(value, 0f, 1f);

            UpdateMesh(transformV);
        }
    }

    private float transformV = 0f;
    private Mesh originalMesh;
    [SerializeField]private Mesh targetMesh;

    [SerializeField]float rotateSpeed = 10f;

    private Vector3[] targetVertices;
    private Vector3[] originalVertices;
    private Vector3[] currentVertices;

    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().mesh;

        targetVertices = targetMesh.vertices;
        originalVertices = originalMesh.vertices;

        if (targetVertices.Length != originalVertices.Length)
            throw new UnityException("unable to transform: target vertices doesn't match with the original mesh");

        currentVertices = new Vector3[originalVertices.Length];

        Progress = 0f;
    }

    void UpdateMesh(float progressValue) 
    {

        for (int i = 0; i < originalVertices.Length; i++)
        {
            currentVertices[i] = Vector3.Lerp(originalVertices[i], targetVertices[i], progressValue);
        }

        originalMesh.vertices = currentVertices;
        originalMesh.RecalculateBounds();
        originalMesh.RecalculateNormals();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f,rotateSpeed,0f);

       // Progress += 0.001f;
    }
}
