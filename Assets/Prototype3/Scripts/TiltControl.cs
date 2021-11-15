using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TiltControl : MonoBehaviour
{
    [Header("Platform")]
    public float speed = 20f;
    Rigidbody rB;

    [Header("Egg")]
    public GameObject eggPrefab;
    private float spawnRange = 2f;

    [Header("Other")]
    public float tweenTime = 1f;


    void Start()
    {
        rB = GetComponent<Rigidbody>();
        SpawnEgg();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        //transform.eulerAngles.y = Mathf.Clamp(transform.eulerAngles.y, -90, -90);
        Vector3 moveVector = new Vector3(moveVertical * speed, 0, -moveHorizontal * speed);
        Quaternion deltaRotation = Quaternion.Euler(moveVector * Time.fixedDeltaTime);
        rB.MoveRotation(rB.rotation * deltaRotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 5f, spawnPosZ);
        return randomPos;
    }

    public void SpawnEgg()
    {
            Instantiate(eggPrefab, GenerateSpawnPosition(), eggPrefab.transform.rotation);
    }

}
