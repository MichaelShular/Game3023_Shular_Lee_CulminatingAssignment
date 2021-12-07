using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "EffectSystem/Damage")]
public class Damage : IEffect
{
    [SerializeField] public int DamageMin;
    [SerializeField] public int DamageMax;

    public override void ApplyEffect(ICharacter self, ICharacter other)
    {
        if (other.hasShield)
        {
            other.hasShield = false;
            return;
        }
        int damage = Random.Range(DamageMin + self.attack, DamageMax + self.attack) - other.defense;
        
        if (damage < 0)
            other.health -= 1;
        else
            other.health -= damage;
        
    }
}
