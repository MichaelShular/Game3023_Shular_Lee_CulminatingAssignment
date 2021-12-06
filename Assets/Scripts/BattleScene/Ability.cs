using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewAbility", menuName = "AbilitySystem/Ability")]
public class Ability : ScriptableObject
{
    [SerializeField] private new string name;

    [SerializeField] private string description;

    [SerializeField] private IEffect[] effects; 

    public void Cast(ICharacter self, ICharacter other)
    {
        //Debug.Log("Cast " + name);
        self.onAbilityCast.Invoke(this, self);

        if (self.incapacitated)
        {
            Debug.Log("Stunned");
            return;
        }
        foreach (IEffect effect in effects)
        {
            effect.ApplyEffect(self, other);
        }
    }
}
