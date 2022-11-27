using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

/// <summary>
/// Singleton GWorld object
/// </summary>
public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;

    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes) {
            cubicles.Enqueue(c);
        }

        if (cubes.Length > 0)
            world.ModifyState("FreeCubicle", cubes.Length);
    }

    private GWorld()
    {
    }

    /// <summary>
    /// Add a patient to patients queue
    /// </summary>
    /// <param name="p">The patient GameObject</param>
    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    /// <summary>
    /// Remove a patient from the queue
    /// </summary>
    /// <returns>The removed patient GameObject</returns>
    public GameObject RemovePatient() {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }

    /// <summary>
    /// Add a cublicles to the queue
    /// </summary>
    /// <param name="c">The cubicle GameObject</param>
    public void AddCubicle(GameObject c)
    {
        cubicles.Enqueue(c);
    }

    /// <summary>
    /// Remove a cubicle from the queue
    /// </summary>
    /// <returns>The removed cubicle GameObject</returns>
    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
