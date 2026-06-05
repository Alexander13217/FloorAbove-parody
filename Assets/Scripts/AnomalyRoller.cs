using System;
using UnityEngine;

public class AnomalyRoller
{
    private int _anomalySpawnChance = 60;
    private int _spawnChanceStep = 10;
    private System.Random _random = new System.Random();
    
    public bool ShouldSpawnAnomaly()
    {
        int chance = _random.Next(1, 101);

        if(chance <= _anomalySpawnChance)
        {
            _anomalySpawnChance -= _spawnChanceStep;
            return true;
        }

        _anomalySpawnChance += _spawnChanceStep;
        return false;
    }
}
