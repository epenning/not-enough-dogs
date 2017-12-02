using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    public float walkInterval = 1F;
    public float directionInterval = 2F;
    public float minSpeed = 1F;
    public float maxSpeed = 5F;

    public float walkTimer;
    public float directionTimer;

    public float walkPercentage = 0.3F;
    public float directionPercentage = 0.8F;
    
    public float direction = 0;
    public float speed = 0;
    
	void Start () {
        walkTimer = walkInterval;
        directionTimer = directionInterval;

        direction = Random.Range(0, 360);
	}
	
	void Update () {
        walkTimer -= Time.deltaTime;
        directionTimer -= Time.deltaTime;

        if (walkTimer < 0) {
            walkTimer = walkInterval;

            if (Random.Range(0F, 1F) < walkPercentage) {
                speed = Random.Range(minSpeed, maxSpeed);
            } else {
                speed = 0;
            }
        }

        if (directionTimer < 0) {
            directionTimer = directionInterval;

            if (Random.Range(0F, 1F) < directionPercentage) {
                direction = Random.Range(0, 360);
            }
        }

        GetComponent<Animator>().SetFloat("Direction", direction);
	}

    void FixedUpdate() {
        Vector2 directionVector = Quaternion.Euler(0, 0, direction) * Vector2.right;
        GetComponent<Rigidbody2D>().velocity = directionVector * speed;
    }
}
