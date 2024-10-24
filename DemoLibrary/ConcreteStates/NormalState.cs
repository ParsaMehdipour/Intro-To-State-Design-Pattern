using DemoLibrary.BaseStates;
using DemoLibrary.Contexts;

namespace DemoLibrary.ConcreteStates;

/// <summary>
/// Concrete States implement various behaviors, associated with a state of
/// the Context.
/// Normal Combat State
/// </summary>
/// <param name="character">Backreference to context</param>
public class NormalState(Character character) : BattleState(character)
{
    public override void OnStateEnter()
    {
        _context.DamageMultiplier = 1.0f;
        _context.DefenseMultiplier = 1.0f;
        _context.SpeedMultiplier = 1.0f;
        Console.WriteLine($"{_context.Name} assumes normal combat stance!");
    }

    public override void OnStateExit()
    {
        Console.WriteLine($"{_context.Name} powers up...");
    }

    public override void Attack()
    {
        if (_context.Energy >= 10)
        {
            Console.WriteLine($"{_context.Name} performs a normal attack!");
            _context.Energy -= 10;
        }
        else
        {
            Console.WriteLine($"{_context.Name} is too tired to attack!");
        }
    }

    public override void Defend()
    {
        Console.WriteLine($"{_context.Name} takes a defensive stance!");
        _context.DefenseMultiplier = 1.5f;
    }

    public override void UseSpecialAbility()
    {
        if (_context.Energy >= 50)
        {
            _context.ChangeState(new BerserkerState(_context));
        }
        else
        {
            Console.WriteLine($"{_context.Name} doesn't have enough energy to transform!");
        }
    }

    public override void TakeDamage(int damage)
    {
        int actualDamage = (int)(damage / _context.DefenseMultiplier);
        _context.Health -= actualDamage;
        Console.WriteLine($"{_context.Name} takes {actualDamage} damage! Health: {_context.Health}");

        if (_context.Health <= 20 && _context.Energy >= 30)
        {
            _context.ChangeState(new SurvivalState(_context));
        }
    }

    public override void Rest()
    {
        Console.WriteLine($"{_context.Name} takes a moment to rest.");
        _context.RestoreEnergy(20);
    }
}

