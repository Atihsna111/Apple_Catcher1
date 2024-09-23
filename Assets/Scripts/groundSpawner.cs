using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    [SerializeField] GameObject ground;
    
    Vector3 spawnPoint;
    public void ShouldSpawn()
    {
        GameObject temp = Instantiate(ground, spawnPoint, transform.rotation ); // to clone 
        spawnPoint = temp.transform.GetChild(1).transform.position; //position of nextspawn to spawn the ground
             
    }

    void Start()
    {
        for(int i =0 ; i< 15 ; i++)
        {
            ShouldSpawn();
        }     
        
    }
}
