using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;
    private GameObject finishLine;
    private void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else{
            instance = this;    
        }
    }
    void Start()
    {
        GenerateLevel();
        finishLine = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    // private void CreateRandomLevel ()
    // {
    //      Vector3 chunkpositon = new Vector3(0,-5.2f,0);
    //     for ( int i = 0 ; i<5; i++)
    //     {
    //         Chunk chunkToCreate = chunkPefabs[Random.Range(0,chunkPefabs.Length)];
    //         if ( i > 0)
    //         {
    //             chunkpositon.z +=chunkToCreate.GetLenght()/2;
    //         }
    //         Chunk chunkInstantiate= Instantiate(chunkToCreate,chunkpositon,Quaternion.identity,transform);
    //         chunkpositon.z +=chunkInstantiate.GetLenght()/2;
          
    //     }
    // }
    void GenerateLevel()
    {
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;
        LevelSO level = levels[currentLevel];
        CreateLevel(level.chunks);
    }
    private void CreateLevel(Chunk[] levelChunks){
        Vector3 chunkpositon = new Vector3(0,-5.2f,0);
        for ( int i = 0 ; i<levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];
            if ( i > 0)
            {
                chunkpositon.z +=chunkToCreate.GetLenght()/2;
            }
            Chunk chunkInstantiate= Instantiate(chunkToCreate,chunkpositon,Quaternion.identity,transform);
            chunkpositon.z +=chunkInstantiate.GetLenght()/2;
          
        }
    }
    public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level", 0);
    }
}
