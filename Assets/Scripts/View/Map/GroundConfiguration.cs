using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/GroundConfig")]
public class GroundConfiguration : ScriptableObject
{
    [SerializeField] private Ground[] ground;
    private Dictionary<string, Ground> idToGround;

    private void Awake()
    {
        idToGround = new Dictionary<string, Ground>(ground.Length);
        foreach (var ground in ground)
        {
            idToGround.Add(ground.Id, ground);
        }
    }

    public Ground GetGroundPrefabById(string id)
    {
        if (!idToGround.TryGetValue(id, out var ground))
        {
            throw new Exception($"ground with id {id} does not exit");
        }
        return ground;
    }
}