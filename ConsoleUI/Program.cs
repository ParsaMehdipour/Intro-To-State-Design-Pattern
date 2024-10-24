using DemoLibrary.Contexts;

var warrior = new Character("Dragon Warrior");

// Normal combat sequence
warrior.Attack();  // Normal attack
warrior.TakeDamage(30);  // Takes damage
warrior.Defend();  // Normal defense

// Build up energy then transform
warrior.Rest();
warrior.Rest();
warrior.UseSpecialAbility();  // Transform to Berserker

// Berserker combat sequence
warrior.Attack();  // Berserker attack
warrior.Attack();  // Berserker attack
warrior.TakeDamage(40);  // Takes increased damage in Berserker

// Character gets heavily damaged and enters Survival state
warrior.TakeDamage(50);  // Automatically switches to Survival state at low health

// Survival combat sequence
warrior.Defend();  // Enhanced defense in Survival
warrior.Attack();  // Survival attack
warrior.Rest();    // Rest to recover