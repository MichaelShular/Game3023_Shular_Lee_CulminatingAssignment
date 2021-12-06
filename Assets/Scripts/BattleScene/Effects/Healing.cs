using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "EffectSystem/Healing")]
public class Healing : IEffect
{
    [SerializeField] public int HealingMin;
    [SerializeField] public int HealingMax;
    public override void ApplyEffect(ICharacter self, ICharacter other)
    {
        int healingAmount = Random.Range(HealingMin, HealingMax);

        if(healingAmount + self.health > self.maxHealth)
        {
            self.health = self.maxHealth;
        }
        else
        {
            self.health += healingAmount;
        }
       
        
    }

}
