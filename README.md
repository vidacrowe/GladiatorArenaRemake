In Gladiator Arena, choose your moves, but watch your opponent.

Game Mechanics:
- Each turn, you choose an action: Strike, Thrust, Parry, or Block. Your opponent will do the same.
- The CPU opponent has a combat AI which defines their attack patterns. Some go on the offense with Strike and Thrust. Others try to counter your actions, Thrust-ing to pierce your guard or Parry to reflect your damage. Others go on the defensive.
- In the middle of battle, the CPU may shift their combat AI depending on the moves of the player. They may switch to minimize the damage they receive or exploit your own attack tendencies.
- Deplete the opponent's HP to win.


Technical Details:

This project was made for the final activity of the Unity Junior Programmer Pathway.
This was initially made as a project for my college programming class, wherein I had to apply object-oriented programming concepts to my code.

The CPU opponent had a combat AI managed through inheritance. There were different child classes that would define how often the CPU opponent will use certain actions.
I added a "strategy shifting" functionality that would make the CPU opponent change combat AI. This was implemented with polymorphism in mind.
At the start of the battle, there will be dialog that will hint at how the opponent will switch strategies, such as switching reduce
the damage they receive or to take advantage of the player's actions and deal more damage.
This dialog will change after switching, hinting at the new combat AI being applied.

When initializing the CPU opponent, the initialization of the CombatAI and StrategyShift objects are abstracted in their own separate private methods.
Meanwhile, variables are encapsulated into properties, defining get/set restrictions.

The old college code once included a "tournament mode" where the player can fight up to 5 enemies in succession;
however, I excluded it from the remake due to scope limitations.
