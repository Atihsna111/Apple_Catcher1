using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _player;
    [SerializeField] float jumpForce = 200f;
    [SerializeField] Animator animator;
    private ScoreManager scoreManager;
  
    public bool alive = true;
    public bool canRun = false;
    private float xRange = 4f;
    float horizontalInput;

    public float speedIncreasePoint = 0.1f;
    public float Speed = 8f;

    
     private void Start()
    {   scoreManager = FindObjectOfType<ScoreManager>(); 
        if(scoreManager != null)
        {
             scoreManager.StartCountdown();
        }
        else{
            Debug.LogError("not working");
        }
        _player= GetComponent<Rigidbody>();
        animator = this.GetComponentInChildren<Animator>();
    
    }
    //notify player to start running
    public void startRunning()
    {
        
        canRun = true;
        Debug.Log("Player can run");

    }

    void Jump()
    {
        _player.AddForce(Vector3.up * jumpForce);
        
    }
    void FixedUpdate()
    { 
        if(!alive || !canRun) 
        {
            animator.speed = 0;
            return;
        }
        else{
            animator.speed =1;
            
            Vector3 forwardMove = transform.forward * Speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * Speed * Time.fixedDeltaTime;
            _player.MovePosition(_player.position + forwardMove + horizontalMove);
        }             
    }
    void Update()
    {
        if(transform.position.x < -xRange)
        {
          transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);   
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.y < -5)
        {
            
            Dead();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    
    }

    public void Dead()
    {
        alive =false;
       canRun = false;
       
    }          
}
