# Todo
* &olcir; Task has not be completed
* &olcross; means complete 
* &ofcir; done but not yet tested

## Main project changes and bugs
* &olcross; Some reason "Start Game" only works 80% of the time.

* &olcross;  We now are properly delievering game tasks (locations and what not).  Filtering should probably happen before sending the data to limit data transfer.  That use locations to filter tasks and then send the list of tasks or even the correct number of randomized tasks.

* &olcross; We also need to fix the thing where the station drop down is getting a non-unique list of locations.

* &olcir; GameController is still trying to communicate with the Java server.  Must comm with the mirror server.

* &ofcir; crewmates win on task is stupid buggy... Make sure it is reset completed task count on start game.  But also imposters might be automatically winning for crew on task complete?

	* &olcross; Resolved for assign imposters, but still an issue for when imposters are assigned manually.

	* &ofcir; Players don't have their task counts reset...

* &olcir; Fix empty garbage wall glitch-error and a catch all for the cases where it does get blocked.  (10 seconds after the lever has been moved?)

* &olcross; Add location name to the stations.

* &olcross; Partial IP station connection.  IE: if the person types 1.80:7777 it will connect based on the current connection of the station computer.  So if the stations IP is 192.168.2.34 it will take the first two numbers from the station's IP and append the input string to get 192.168.1.80:7777.  This will be more error prone but could be faster for typing in.

	* &olcir; Or just setup network discovery for stations but I'm too lazy to do that right now.

* &ofcir; Add stuff for the RANDOM ROOM usage.
	
	* &ofcir; Proper assignment of random tasks
	
* &olcir; Show menu options on bg click for station/hub main menu.
## Future Plans
* &olcir; Create a separate security panel that allows either wifi or bluetooth communication to render the camera feed from connected phones (up to 6 probably?)

* &olcir; Implement admin panel as a station that communicates more actively though sync vars and commands and the like.  This would allow for multiple admin panels, or the placement of the admin panel in a different room

* &olcir; Task list builder, probably added to the hub

* &olcir; Login for some reason?

* &olcir; Voting from client

* &olcir; Player color selection.  Probably need at least 30 base colors and possible variants.  Color use is actually in existence already, it will just need to be managed with players allowing for selection, and to check if that color is taken.  This could be important for voting, we'll see.