using UnityEngine;


[CreateAssetMenu(fileName = "Death Effect", menuName = "Player Death/Create", order = 1)]

public class DeathScriptableObject: ScriptableObject
{
    [field: SerializeField] public ParticleSystem DeathEffect { get; private set; } 
}
