using DemoLibrary.Contexts;

namespace DemoLibrary.ConcreteStates;

/// <summary>
/// Concrete States implement various behaviors, associated with a state of
/// the Context.
/// Berserker State - High damage, low defense
/// </summary>
/// <param name="character">Backreference to context</param>
public class BerserkerState(Character character) : NormalState(character)
{
    private int _rageCounter = 0;

    public override void OnStateEnter()
    {
        _context.DamageMultiplier = 2.0f;
        _context.DefenseMultiplier = 0.5f;
        _context.SpeedMultiplier = 1.5f;
        _context.StatusEffects["Rage"] = 3;
        Console.WriteLine($"{_context.Name} enters a berserker rage! Attack power doubled but defense halved!");
    }

    public override void Attack()
    {
        if (_context.Energy >= 15)
        {
            Console.WriteLine($"{_context.Name} unleashes a devastating berserker attack!");
            _context.Energy -= 15;
            _rageCounter++;

            if (_rageCounter >= 3)
            {
                Console.WriteLine($"{_context.Name}'s rage subsides...");
                _context.ChangeState(new NormalState(_context));
            }
        }
        else
        {
            Console.WriteLine($"{_context.Name} is too exhausted to maintain the berserker state!");
            _context.ChangeState(new NormalState(_context));
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _context.Energy -= 10; // Berserker state drains energy when taking damage
    }
}