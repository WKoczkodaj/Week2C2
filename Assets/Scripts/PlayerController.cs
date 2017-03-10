using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    public GameObject laser;
    public Transform laserSpawn;

    private Rigidbody2D rb;

    private float nextFire = 0.3f;
    private float myTime = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);

            myTime = 0.0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
    }
}
