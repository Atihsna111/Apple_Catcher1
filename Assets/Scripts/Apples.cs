using System.Collections;
using UnityEngine;

public class Apples : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    [SerializeField] private AudioClip _audio;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    IEnumerator PlaySound()
   {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = _audio;
        audioSource.Play();
        yield return new WaitForSeconds(_audio.length);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            StartCoroutine (PlaySound());
            return;
        }
        //Check that the object we collided with is the player
        if(other.gameObject.name != "Player")
        {
            return;
        }
         // player's score
        ScoreManager.inst.IncrementScore();

        // Destroy the coins
        StartCoroutine(PlaySound());
    }      

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }
}
