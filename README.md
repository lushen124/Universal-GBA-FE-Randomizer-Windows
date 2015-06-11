# Universal-GBA-FE-Randomizer-Windows
A Universal Randomizer for Fire Emblem games on Game Boy Advance

## Latest Updates

June 10, 2015 - Created Repository and Initial Check-in of code. Basic functionality works for all games (randomizing growths, bases, CON, MOV, affinities, and items). Random classes only works with FE6 at the moment. Working through issues with FE6 classes. 

## Purpose
The intent for this project was to create an easy-to-use and customizable randomizer for use with the Fire Emblem games for Game Boy Advance. This includes Fire Emblem: Sword of Seals (JP), Fire Emblem (NA), and Fire Emblem: The Sacred Stones (NA). This application simply reads the game data (from a *.gba file) and directly modifies the bytes in the data tables to generate a version of the game that may contains randomized classes, growths, items, and so on. 

### FE6 Notes

* Random classes are available for most playable characters and bosses. Problems arise with playable characters and bosses that are scripted to move in events and can fly (Miledy, Gale, Narcian) and fly across otherwise impassable terrain (bodies of water and mountains). One option is to randomize them only with other flying classes, but that drastically cuts down on the possibilties (basically Wyvern Knight or Pegasus Knight). At the moment, they just won't be randomized.
* There have been reports of freezing of games occurring with the randomizer. I have not yet been able to reproduce on my end, but if you do encounter this, please let me know what parameters you used and under what condition you managed to do so. A UPS patch of the result would also be very helpful. NUPS can help you create one if you have the randomized game as well as the base game.
* It should be noted that I am testing using the 0.99b version of the Redux translation patch. Quickly testing out the v1.0 version of the patch seems to yield some odd issues with infinite vulneraries, which I'll have to look into. You can find the Redux translation patch (both 1.0 and older versions) here: http://serenesforest.net/forums/index.php?showtopic=41095

### FE7 Notes

### FE8 Notes

## Future Plans

The remaining feature list (which you can get a sneak peek at with the app) is as follows:

* Random Classes for FE7 and FE8
* Random Affinity Bonuses (Seems a bit overpowered since the only direction it can go is up)
* Option to Buff Enemy Units (via increased growths)
* Option to Randomize regular enemies
* Random or Reverse Recruitment Order
* Attempt to un-messify color palettes for randomized classes.

I still need to implement a Mac version which will be written in Objective-C later. If there is demand for a Linux version, I'll do that after Mac.
