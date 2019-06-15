using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerMovementController : MonoBehaviour {

    public float playerSpeed = 10f;
    public ParticleSystem particleSystem;
    [SerializeField] float startTimeBetweenTrail = 0.4f;
    Animator animator;
    float timeBetweenTrail;
    void Start() {
        animator = GetComponent<Animator>();
        timeBetweenTrail = startTimeBetweenTrail;
    }

    void Update() {
        SetMovementAnimationParams(GetPlayerInputVector());
        Movement(GetPlayerInputVector());
        if(GetPlayerInputVector().magnitude > 0) {
            if(timeBetweenTrail <= 0) {
                particleSystem.Play();
                timeBetweenTrail = startTimeBetweenTrail;
            }
            else {
                timeBetweenTrail -= Time.deltaTime;
            }
        }
        if(GetPlayerInputVector() != Vector3.zero) {
            Vector3 previousNonZeroInput = GetPlayerInputVector();
        }
    }

    void SetMovementAnimationParams(Vector3 movement) {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
    }

    Vector3 GetPlayerInputVector() {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    }

    void Movement(Vector3 input) {
        transform.position = transform.position + input * Time.deltaTime * playerSpeed;
    }

}
