﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numPatients;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPatients; i++)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        }

        Invoke("SpawnPatient", 10);
    }

    void SpawnPatient()
    {
        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(10, 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
