using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : ICharacter
{
    [SerializeField] Encounter myEnounter;

    public void CastAbility(int slot)
    {
        UseAbilty(slot, this, myEnounter.enemy);
    }
    public override void TakeTurn(Encounter encounter)
    {
        myEnounter = encounter;
    }

}
