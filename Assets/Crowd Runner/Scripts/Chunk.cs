using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Settings")]
    [SerializeField] private Vector3 size;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetLenght()
    {
        return size.z;
    }
    public void OnDrawGizmos() {
        Gizmos.color=Color.blue;
       Gizmos.DrawWireCube(transform.position,size); 
    }
}
