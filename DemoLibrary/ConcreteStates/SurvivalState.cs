using DemoLibrary.Contexts;

namespace DemoLibrary.ConcreteStates;

/// <summary>
/// Concrete States implement various behaviors, associated with a state of
/// the Context.
/// Survival State - Activated at low health
/// </summary>
/// <param name="character">Backreference to context</param>
public class SurvivalState(Character character) : NormalState(character)
{
    private int _survivalTurns = 3;

    public override void OnStateEnter()
    {
        _context.DamageMultiplier = 1.2f;
        _context.DefenseMultiplier = 2.0f;
        _context.SpeedMultiplier = 1.3f;
        Console.WriteLine($"{_context.Name} enters survival mode! Defense greatly increased!");
        _context.Heal(20); // Emergency healing
    }

    public override void Attack()
    {
        base.Attack();
        _survivalTurns--;
        CheckSurvivalDuration();
    }

    public override void Defend()
    {
        Console.WriteLine($"{_context.Name} takes a highly defensive stance!");
        _context.DefenseMultiplier = 3.0f; // Enhanced defense in survival mode
        _context.Heal(10);
        _survivalTurns--;
        CheckSurvivalDuration();
    }

    private void CheckSurvivalDuration()
    {
        if (_survivalTurns <= 0)
        {
            Console.WriteLine($"{_context.Name} can no longer maintain survival mode!");
            _context.ChangeState(new NormalState(_context));
        }
    }
}
