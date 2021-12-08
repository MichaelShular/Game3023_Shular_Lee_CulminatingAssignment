using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ICharacter : MonoBehaviour
{
    [SerializeField] public List<Ability> abilities;
    public int health;
    public int maxHealth;
    public bool hasShield;
    public bool incapacitated;
    public Slider healthBar;    
    public int attack;
    public int defense;
    private Encounter encounter;
    public UnityEvent<Ability, ICharacter> onAbilityCast;    
    public List<PokemonBase> pokemons;
    public PokemonBase currentPokemon;
    public void UseAbilty(int abilitySlot, ICharacter self, ICharacter opponent)
    {
        abilities[abilitySlot].Cast(self, opponent);
    }
    private void Start()
    {
        healthBar = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }


    public abstract void TakeTurn(Encounter encounter);
}
