using DemoLibrary.BaseStates;
using DemoLibrary.ConcreteStates;

namespace DemoLibrary.Contexts;

/// <summary>
/// The Context defines the interface of interest to clients. It also
/// maintains a reference to an instance of a State subclass, which
/// represents the current state of the Context.
/// </summary>
public class Character
{
    // A reference to the current state of the Context.
    private BattleState _currentState;
    public string Name { get; private set; }
    public int Health { get; set; } = 100;
    public int Energy { get; set; } = 100;
    public bool IsAlive => Health > 0;
    public Dictionary<string, float> StatusEffects { get; } = new Dictionary<string, float>();

    // Stats that can be modified by states
    public float DamageMultiplier { get; set; } = 1.0f;
    public float DefenseMultiplier { get; set; } = 1.0f;
    public float SpeedMultiplier { get; set; } = 1.0f;

    public Character(string name)
    {
        Name = name;
        // Start in normal combat state
        _currentState = new NormalState(this);
    }

    // The Context allows changing the State object at runtime.
    public void ChangeState(BattleState newState)
    {
        _currentState?.OnStateExit();
        Console.WriteLine($"\n{Name} transforms from {_currentState?.GetType().Name.Replace("State", "")} → {newState.GetType().Name.Replace("State", "")}!");
        _currentState = newState;
        _currentState.OnStateEnter();
    }

    // Core combat actions
    public void Attack() => _currentState.Attack();
    public void Defend() => _currentState.Defend();
    public void UseSpecialAbility() => _currentState.UseSpecialAbility();
    public void TakeDamage(int damage) => _currentState.TakeDamage(damage);
    public void Rest() => _currentState.Rest();

    // Utility methods used by states
    public void RestoreEnergy(int amount)
    {
        Energy = Math.Min(100, Energy + amount);
        Console.WriteLine($"{Name} restored {amount} energy. Current energy: {Energy}");
    }

    public void Heal(int amount)
    {
        Health = Math.Min(100, Health + amount);
        Console.WriteLine($"{Name} healed for {amount}HP. Current health: {Health}");
    }
}
