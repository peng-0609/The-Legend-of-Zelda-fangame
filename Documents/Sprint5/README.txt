Commands
-----------------
Press Arrow Keys or WASD to move Link
Press Number Key 1 to use selected projectile
Press Number Key 2 to attack using Sword
Press Enter to Pause/Restart the game
Press I to enter Menu
	In Menu: Press Left/Right Keys to select projectile for attacking
		 Press Enter to determine selection.
		 Press Q to return to game
Press Q to return from game to starting state
----------------

New Features
----------------
1. Cheatcodes
Press MB	Player will have 99 bombs.
Press MR	Player will have 99 Rupees.
Press MK	Player will have 99 keys.
Press MH	Link's current Health will change to his MaxHealth.

2. One HP Mode
Link only has 1HP as his health and his max health. HeartCountainer doesn't work in this mode.

3. Unlimited Mode
Room with unlimited enemies and Link only has 6HP.
Link will have 10 bombs and all other kinds of his projectiles at the beginning of this mode.
Player earns score by killing enemies. 1 enemy = 5 points.

Notes On Code Analysis
----------------
There are 0 error,103 warnings according to the rule set 'Microsoft Basic Design Guideline Rules'. Most of them are still recommandations 
of renaming variables such as 'x', 'y' which represents positions. Some of them are recommendations of setting property as read-only, but
we plan to change their values in other classes.
There are also suggestions about changing List<T> to Colleciton<T>, but we don't figure out the advantage of this modification.

There are some warnings that we cannot understand such as:

Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA0507	Post-build Code Analysis (FxCopCmd.exe) has been deprecated in favor of FxCop analyzers, which run during build. Refer to https://aka.ms/fxcopanalyzers to migrate to FxCop analyzers.				Active

