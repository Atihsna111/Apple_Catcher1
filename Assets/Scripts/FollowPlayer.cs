using UnityEngine;
using UnityEngine.SceneManagement;

public class followPlayer : MonoBehaviour
{
    
   [SerializeField] Transform player;
    private Vector3 Offset;
    
    void Start()
    {
        Offset = transform.position - player.position;
        
    }
    void Update(){
        Vector3 targetPos = player.position + Offset;
        targetPos.x = 0;
         transform.position = targetPos; 
    }

    
}
