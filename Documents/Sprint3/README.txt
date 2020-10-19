Commands
-----------------
Press Arrow Keys or WASD to Change Link's Facing Direction and Press Again to Move Link
Press Z or N to Attack using Sword
Press Number Key 1 to Use Bomb (If use bomb in running state, Link will stop and put down a bomb.)
Prese Number Key 2 to Attack using Sword
Press M to Use the Map and Click to Swicth to other Room
Press R to Reset the Game
Press Q to Quit the Game
----------------

Descriptions of known bugs that program has
-----------------
1. The enemy will become enemycloud and still alive when it is being killed. We think that is because we lack some states of enmeies. We will fix it in the next Sprint.
2. Link cannot use the boomerang projectile but we will fix it in the next Sprint.
3. Trap movement is unfinished.

10/20 UPDATE: Fixed bug1.
10/22 UPDATE: Changed Link's running states such that link is able to use bomb when running. Link would stop and put a bomb in front of him.

Notes On Code Analysis
----------------
There are 0 error, 77 warnings according to the rule set 'Microsoft Basic Design Guideline Rules'. Most of them are recommandations 
of renaming variables such as 'x', 'y' which represents positions. The rule set cannot recognize terms such as enemies names. A few 
warnings about unused variables are fixed by commenting these variables, since they will be used in the future.

There are still some warnings that we don't understand. We pick some of them and list as following:

Severity	Code	Description	Project	File	Line	Suppression State		
Warning	CA1002	Change 'List<IItem>' in 'Level.Items' to use Collection<T>, ReadOnlyCollection<T> or KeyedCollection<K,V>	Sprint3
Severity	Code	Description	Project	File	Line	Suppression State
Warning	CA2227	Change 'Level.Blocks' to be read-only by removing the property setter.	Sprint3
