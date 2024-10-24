using DemoLibrary.Contexts;

namespace DemoLibrary.BaseStates;

/// <summary>
/// The base State class declares methods that all Concrete States should
/// implement and also provides a backreference to the Context object,
/// associated with the State. This backreference can be used by States to
/// transition the Context to another State.
/// </summary>
public abstract class BattleState
{
    protected Character _context;

    protected BattleState(Character context) => _context = context;
    public abstract void OnStateEnter();
    public abstract void OnStateExit();
    public abstract void Attack();
    public abstract void Defend();
    public abstract void UseSpecialAbility();
    public abstract void TakeDamage(int damage);
    public abstract void Rest();
}
