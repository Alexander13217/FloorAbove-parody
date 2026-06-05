using System;
using UnityEngine;

public class AnomalyRoller
{
    private int _currentSpawnChance = 60;
    private int _spawnChanceStep = 10;
    private System.Random _random = new System.Random();
    
    public bool ShouldSpawnAnomaly()
    {
        int chance = _random.Next(1, 101);

        if(chance <= _currentSpawnChance)
        {
            _currentSpawnChance = Mathf.Clamp
            (
                _currentSpawnChance - _spawnChanceStep,
                0,
                100
            );
            return true;
        }

        _currentSpawnChance = Mathf.Clamp
        (
            _currentSpawnChance + _spawnChanceStep,
            0,
            100
        );

        return false;
    }
}
