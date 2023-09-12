using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform runnersParent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runners = runnersParent.GetChild(i);
            Animator runnersAnimator = runners.GetComponent<Animator>();
            runnersAnimator.Play("Run");
        }
    }
    public void Idle()
    {
         for (int i = 0; i < runnersParent.childCount; i++)
        {
            Transform runners = runnersParent.GetChild(i);
            Animator runnersAnimator = runners.GetComponent<Animator>();
            runnersAnimator.Play("Idle");
        }
    }
}
