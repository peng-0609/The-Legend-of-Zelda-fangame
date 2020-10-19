Commands
-----------------
Press Arrow Keys or WASD to move Link
Press Number Key 1 to use selected projectile
Press Number Key 2 to attack using Sword
Press Enter to Pause/Restart the game
Press I to enter Menu
	In Menu: Press Left/Right Keys to select projectile for attacking
		 Press Enter to determine selection.
Press Q to return from Menu to game
Press M to Use the Map and Click to Swicth to other Room 
----------------

Note
----------------
In current sprint we don't need to pick the sword
For testing purpose, our link has unlimited keys so we don't need to check KeyCount before open the locked doors.
We used camera to move the background spritesheet.We didn't figure out how to change background when using mouse controller.

Descriptions of known bugs
-----------------


Notes On Code Analysis
----------------
There are 0 error, 110 warnings according to the rule set 'Microsoft Basic Design Guideline Rules'. Most of them are still recommandations 
of renaming variables such as 'x', 'y' which represents positions. Some of them are recommendations of setting property as read-only, but
we plan to change their values in other classes.
There are also suggestions about changing List<T> to Colleciton<T>, but we don't figure out the advantage of this modification.

There are some warnings that we cannot understand such as:

Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA0507	Post-build Code Analysis (FxCopCmd.exe) has been deprecated in favor of FxCop analyzers, which run during build. Refer to https://aka.ms/fxcopanalyzers to migrate to FxCop analyzers.				Active

