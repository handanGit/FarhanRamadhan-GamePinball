using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Bumper : MonoBehaviour
{
    public Collider ball;
    public float multiplier;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxmanager;
    public Score_Manager scoreManager;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == ball)
        {
            Rigidbody ballRig = ball.GetComponent<Rigidbody>();
            ballRig.velocity *= multiplier;

            //animation function
            animator.SetTrigger("Hit");

            //play sfx
            audioManager.playSFX(collision.transform.position);

            //play vfx
            vfxmanager.playVFX(collision.transform.position);

            //add score
            scoreManager.AddScore(score);

            Debug.Log("Bumper hit");
        }
    }
}
