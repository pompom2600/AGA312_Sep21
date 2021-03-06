using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); }

    void Update(){
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        if (player.transform.position.y < 1)
            enemyRb.AddForce(lookDirection * speed, ForceMode.Force);

        if (transform.position.y < -10)
            Destroy(gameObject); }

}
