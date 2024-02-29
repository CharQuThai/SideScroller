using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    [SerializeField] Rigidbody rb;
    [SerializeField] GameManger gameManager;
    private float jumpForce = 12f;

    private AudioSource audioSrc;

    private bool grounded = true;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if(audioSrc == null )
        {
            Debug.LogWarning("missing audio source on player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded && !dead)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSrc.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            explosionParticle.Play();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            dead = true;
            dirtParticle.Stop();
            audioSrc.PlayOneShot(crashSound);
            gameManager.EndGame();

        }
    }

    public void Reset()
    {

        dead = false;
        anim.SetBool("Death_b", false);

        int deathLayerIndex = anim.GetLayerIndex("Death");
        anim.Play("Death.Alive", deathLayerIndex);
        dirtParticle.Play();

    }
}
