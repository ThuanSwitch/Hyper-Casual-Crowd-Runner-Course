using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform runnersParents;
    [SerializeField] private TextMeshPro crowdCounterText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crowdCounterText.text=runnersParents.childCount.ToString();
        if( runnersParents.childCount <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
