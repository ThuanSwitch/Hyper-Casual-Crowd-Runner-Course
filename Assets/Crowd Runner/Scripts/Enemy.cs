using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    enum State { Idle, Running}
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    private State state;
    private Transform targetRunner;
    public static Action onRunnersDie;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManegerState();
    }
    void ManegerState()
    {
        switch(state)
        {
            case State.Idle:
                SearchForTarget();
            break;
            case State.Running:
                RunTowardsTarget();
            break;
        }
    }
    void SearchForTarget()
    {
        Collider[] detectedColoders = Physics.OverlapSphere(transform.position, searchRadius);
        for (int i = 0; i < detectedColoders.Length; i++)
        {
            if (detectedColoders[i].TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                    continue;

                runner.SetTarget();
                targetRunner = runner.transform;

                StartRuningTowardsTarget();
            }
        }
    }
    void StartRuningTowardsTarget()
    {
        state = State.Running;
        GetComponent<Animator>().Play("Run");
    }
    void RunTowardsTarget()
    {
        if (targetRunner == null)
        {
            return;
        }
        transform.position  = Vector3.MoveTowards(transform.position, targetRunner.position, Time.deltaTime * moveSpeed);
        if (Vector3.Distance(transform.position, targetRunner.position) < .1f)
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
            onRunnersDie?.Invoke();
        }    
    }
    
}
