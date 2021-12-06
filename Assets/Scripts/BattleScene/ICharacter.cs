using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ICharacter : MonoBehaviour
{
    [SerializeField] public Ability[] abilities;
    [SerializeField] public int health;
    public int maxHealth;
    public bool hasShield;
    public bool incapacitated;
    public Slider healthBar;

    private Encounter encounter;
    public UnityEvent<Ability, ICharacter> onAbilityCast;
    public void UseAbilty(int abilitySlot, ICharacter self, ICharacter opponent)
    {
        abilities[abilitySlot].Cast(self, opponent);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        hasShield = false;
        incapacitated = false;
        healthBar = this.GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }


    public abstract void TakeTurn(Encounter encounter);
}
