using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSysterm : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private PlayerAnimator runnerAnimator;
    [SerializeField] private Transform runnerssParent;
    [SerializeField] private GameObject runnerPrefabs;
    [Header("Setting")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.IsGameState())
            return;
        PlaceRunners();
        if (runnerssParent.childCount <= 0)
            GameManager.instance.SetGameState(GameManager.GameState.GameOver);
    
    }
    private void PlaceRunners(){
         
        for ( int i = 0; i  < runnerssParent.childCount;i++)
        {
            
            Vector3 childLocalPosition = GetRunerLocalPosition(i);
            
            runnerssParent.GetChild(i).localPosition = childLocalPosition;
        }
    }
    private Vector3 GetRunerLocalPosition( int index)
    {
        float x = radius  * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius  * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x,0,z);
    }
    public float GetCrowdRadius(){
        return radius * Mathf.Sqrt(runnerssParent.childCount);
    }
    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount);
            break;
            case BonusType.Multiplication:
                int runnersToAdd = (runnerssParent.childCount * bonusAmount)- runnerssParent.childCount;
                AddRunners(runnersToAdd);
            break;
            case BonusType.Subtraction:
                RemoveRunners(bonusAmount);  
            break;
            case BonusType.Division:
                int runnersToDivision = runnerssParent.childCount - (runnerssParent.childCount/bonusAmount);
                RemoveRunners(runnersToDivision);
            break;
        }
    }
    private void AddRunners(int bonusAmount)
    {
        for ( int i = 0; i < bonusAmount ; i++)
        {
            Instantiate(runnerPrefabs,runnerssParent);

        }
        runnerAnimator.Run();
    }
    private void RemoveRunners(int bonusAmount)
    {
        if ( bonusAmount > runnerssParent.childCount)
        {
            bonusAmount = runnerssParent.childCount;
        }
        int runnersAmount = runnerssParent.childCount;
        for ( int  i = runnersAmount-1; i >= runnersAmount - bonusAmount; i--)
        {
               Destroy(runnerssParent.GetChild(i).gameObject);         
        }
    }

}
