using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset; // Desplazamiento inicial de la cámara respecto de la esfera
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position; 
    }
        
    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
