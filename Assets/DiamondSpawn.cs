using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class DiamondSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    GameObject spawnGameObject;

    Random rand = new Random();
    float time = 0;
    float interval = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        time += Time.deltaTime;
        if (time>interval)
        {
            interval += 2f;
            changePos();
            spawnGameObject = Instantiate(spawnPrefab, transform.position, spawnPrefab.transform.rotation);
        }
    }

    public void changePos()
    {
        transform.position = new Vector3(rand.Next(-75, -25), 30, rand.Next(-2, 15));
    }

}