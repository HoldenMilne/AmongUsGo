# Among Us Go!

Among Us Go! is a game fusingthe party game Mafia, and the popular game by Inner Sloth, Among Us.  

In Among Us the players are split up into 2 groups: crewmates and imposters. The crewmates are just trying to do their job of keeping the ship functioning, while the imposters are trying to sabotage the operation by causing issues that the crewmates must address, or by killing all of the crewmates. Mafia, traditionally, works the same say except with townfolk as the crewmates and mafia as the imposters. The key difference is that in Among Us crewmates complete tasks. 

Tasks are both good and bad for the crewmates. On one hand, they're a way for the crewmates to win. Should they complete every task, then they win. However, they are a distraction, and can sometimes lead you to being alone in the electrical room, ripe for the killing.

Mafia, being a party game, is generally played in person, and all you need to play it is a deck of cards. However, without tasks it can be hard for the Mafia to do any killing. So this project allows for you to play Mafia, but with tasks, adding to the game the risks and rewards of task completion.

# Overview
The game works in more or less 3 components: A Hub, stations and clients.  Stations and Clients connect to the Hub to communicate.  

## Hub
The Hub is the core of the system.  It manages all of the settings, game data etc.  Things like whether to assign imposters and the assignment of imposters, keeping track of the number of completed tasks and whether the game is over, and updating the clients on game end and voting periods.

### Settings
 The hub has a number of settings available that change the behaviour of the game.  Some of these should be set BEFORE connecting any stations, as some settings can cause the stations to break without warning.  These will be denoted with (!). 
 * Number of Short Tasks - The number of short tasks assigned to players at game start.
 * Number of Long Tasks - The number of long tasks assigned to players at game start.
 * Number of Imposters - The number of imposters either assigned by the Hub or the number that WILL be assigned by the game managers.
 * Voting Time - The time in which voting is allowed to take place.  Currently voting is done manually but a voting system is planned to be available through the clients.
 * Alarm - The name of the alarm played when voting time is up.
 * TaskListName - The name of the file where the tasks are drawn from.  There is a default task list distributed with this program that can be modified as you please.  In the future I intend to add something to build these lists.
 * Assign Imposters - Tells the hub whether you want to assign imposters manually or if you want the hub to do it.  Setting this to true tells the Hub to assign imposters automatically.
 * Ghosts Visit Stations - This determines the behavior if the crewmates are killed.  If you have some way to indicate a player is a ghost, then the ghosts can visit stations (After the next meeting has been called).  If this is turned off, ghosts will have a countdown timer of ten seconds and then they will be able to click on the tasks on their task list to do them.
 * Crew Wins on Task Completion - This tells the hub whether or not to alert players to the game end if the crewmates complete all their tasks.  This behaviour depends on the assign imposters setting. If this setting is set to false, completing tasks has no major effect on the game. 
 * Use as Admin Panel - There is a feature to turn the hub into an admin panel in which players last locations are tracked.  This will be discussed later, but if you want to use this turn this setting on.
 * Show Role on Dead - Turning this on forces the player screen when they select "I am dead".  In the future this will be done automatically on the voting screen when voting is implemented in the client.
 
## Station
The Stations are locations in which players will go to in order to complete their tasks.  Generally, these stations are computers running the station program that displays the station code (which I will describe shortly), but due to its passive nature, if you are short on computers you can run several stations on the same computer and write down the station code on a piece of paper and place that in the corresponding room.

Stations work by communicating their information with the hub.  On creation they select a location, and generate a station code, and tell the Hub these two piece of information together.  Players will use the station code displayed on the screen of the station, which is sent to the Hub and the client is told by the Hub to load the correct game.  This is pretty much all their is to the stations.

## Client
Clients are the players in the system.  They are a program run on a mobile device and each player must have one to participate.  Players will carry these devices with the game loaded and connected to the hub to various stations depending on their task lists.  Then upon arrival they will enter the station code communicate which station they are at with the Hub, the hub will tell the client the location and a task-game will be loaded.  Upon completion of the task there are two things that may happen depending on the game settings.
  1. If the Hub is assigning imposters then the task success will be reported to the hub and the task list will be loaded automatically.
  2. If the Hub is NOT assigning imposter then a dialog will pop up asking if the user would like to report the task success.

In the second case, the way that task completion is managed is by taking the total number of tasks per person times the number of non-imposter players and comparing that to the actual number of completed tasks.  Simply, if $s$ is the number of short tasks and $l$ is the number of long tasks, $n$ is the number of players and $i$ is the number of imposters, then the number of completed tasks needed must be at least $(s+l)\cdot(n-i)$
  
