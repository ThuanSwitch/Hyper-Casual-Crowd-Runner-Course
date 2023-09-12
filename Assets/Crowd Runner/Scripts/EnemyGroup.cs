using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Element ")]
    [SerializeField] private Enemy enemyPrefbs;
    [SerializeField] private Transform enemyParents;

    [Header("Setting")]
    [SerializeField] private int amount;
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    void Start()
    {
        GenerateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void GenerateEnemy()
    {
        for ( int i = 0; i < amount;i++)
        {
            Vector3 enemyLocalPosition = GetRunerLocalPosition(i);
            Vector3 enemyWordPosition = enemyParents.TransformPoint(enemyLocalPosition);   
            Instantiate(enemyPrefbs, enemyWordPosition,Quaternion.identity,enemyParents);
        }
    }
     private Vector3 GetRunerLocalPosition( int index)
    {
        float x = radius  * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius  * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x,0,z);
    }
}
