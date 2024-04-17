# IntSysP2
# Introduction to scripting tutorial + additional changes
First of all I did both parts of the tutorial, so I take as a base for the modifications the end of the second tutorial.
I did the following modifications;
1. **Decreasing the velocity of the Hay Machine over time:** I added the feature of the movement velocity of the HayMachine to decrease as time passes to increase the difficulty it starts at velocity 30 and goes down all the way to 10 during a span of 200 seconds.
2. **I added a timer**: To be able to see the amount of time the player last before losing.
   2.1 **Added a sprite and text**: To show it into the canvas, it has a sprite and is showed next to the two sheep counters (Hit and fall).
   2.2 **Restart timer for each game**: When returning to the menu because you click (esc) or is game over and press start again the timer is reset to 0.
   2.3 **Time you lasted**: The time the player lasted in the game is showed in the game over screen (canvas)
