using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "AbilitySystem/PlayerAbility")]
public class PlayerAbility : ScriptableObject
{    
    public List<Ability> currentAbility;
}
