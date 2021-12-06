using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "EffectSystem/Sheild")]
public class Shield : IEffect
{
    public override void ApplyEffect(ICharacter self, ICharacter other)
    {
        self.hasShield = true;
    }
}
