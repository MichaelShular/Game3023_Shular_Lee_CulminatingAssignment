using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "EffectSystem/Stun")]

public class Stun : IEffect
{
    public override void ApplyEffect(ICharacter self, ICharacter other)
    {
        int chanceToStun = Random.Range(0, 100);
        if (!other.incapacitated && chanceToStun > 60)
        {
            other.incapacitated = true;
        }
    }
}
