# Universal-GBA-FE-Randomizer-Windows
A Universal Randomizer for Fire Emblem games on Game Boy Advance

## Latest Updates

**October 1, 2015**

v1.1.0 Release

New Features:
* Added ability to generate a changelog to quickly access most relevant changes (Characters, Classes, Items).

Bug Fixes:
* Updated logic to attempt to transfer a character's highest weapon rank when changing his/her class. The old logic introduced bugs that caused every character to start with A rank weapon levels.

**July 19, 2015**

v1.0.1 Release

Changes:
* Added logic to make sure legendary weapons don't show up prematurely.
* Updated logic for movement costs to only update them for classes of units that need them (FE6: Miledy and Gale, FE7: Fiora and Farina, FE8: Glen and Valter).
* Removed Enemy Buff: At least Amount.
* Added Cross Gender option when randomizing classes.
* Fixed an issue where FE8 monster weapons were getting 1-2 range causing crashes.
* Fixed an issue where FE8 wasn't determining an appropriate promoted class for trainees (should only affect random recruitment).

**July 10, 2015**

**Official Release!** - With this release adding support for new summoners to still be able to summon monsters and truly fixing the monster weapons showing up unintentionally, I think this puts FE8 in a good enough place for me to call it an official release. All three games have been tested enough to be reasonably stable with most setting combinations.

The remaining features to be worked on are mostly cosmetic, so we'll save those for v1.1 maybe. I also have some ideas to play around with some of the settings to give even more control, so maybe there will be a v2.0 as well.

I also need to get on the mac version soon. :laughing:

**July 8, 2015**

*Beta Release* - A real one this time. This one should hopefully solve issues with Eirika disappearing in Chapter 1. The counts for the previous chapter's units were wrong (1 too many) so it was overwriting important data for Chapter 1 (i.e. where Eirika moves to when she initially spawns).

**June 30, 2015**

*Beta Release* - Fixed a lot more issues that surfaced with the additional testing efforts and added support for FE8 random classes and recruitment. The other notable change across all games is the new ability to promote the Soldier class into General (or Paladin in FE8) with Knight's Crests. Additionally, if lords are randomized, they also can now promote using the Knight Crest (Hero Crest for Lyn).

**June 28, 2015**

First pass at randomizing FE8 classes.

**June 25, 2015**

Added logic to make sure lords randomize as classes that can promote and bosses randomize as classes that can attack (FE7 already had this, but I applied it to FE6 as well).

Fixed an issue where Chapter 1 units for FE6 were not getting randomized inventories after randomizing classes.

**June 24, 2015**

Fixed a serious issue with chapter events being corrupted for reinforcements. I had forgotten to exclude 0x00 as a valid class when looking at chapter units so in some cases, it could end up overwriting critical code controlling reinforcements, forcing a trap reset of the game when those reinforcements attempted to spawn.

**June 23, 2015**

Added logic to modify the movement types to use 30 instead of 255 to mark impassable terrain. This should fix problems with characters getting assigned different classes and not being able to spawn in their normal location because their new class doesn't support the same movement type as their old class (namely fliers spawning on mountains and water). This seems to also fix the issue with Miledy in FE6.

**June 20, 2015**

Fixed an issue with characters with custom battle animations still attached after being assigned a new class.

Updated to use Arch's Tutorial Slayer patch for FE7 instead of Blazer's Tutorial Killer patch due to a glitch found in Chapter 7 of Lyn Mode.

Added logic to ensure that lords and bosses, when being assigned a random class, are guaranteed to get a class that can attack.

Added guards against re-randomization of games. Will now throw up a warning if it detects a randomized game is being submitted for randomization again. Will still give the option of doing so, if desired.

**June 19, 2015**

*Beta Release* - Worked out a ton of issues with FE7 and hopefully should be in a testable state now. I tested the first two chapters of Eliwood and Hector mode a little bit and they seem to work, although I am soliciting ideas for how to handle Athos for reverse recruitment, as his stats would be broken as an Archsage, but he has no growths (save for 25% RES, I think) to support an unpromoted class like a Mage.

**June 18, 2015**

Added the ability to apply patches. Currently for use with FE7 to remove the tutorial, using a patch from Blazer. 

Still need to find a solution for Reverse Recruitment and Athos being demoted. Will probably create a new class, but I'm not sure what. Or he could just be mage -> sage. Athos also has no growths by default, so he'll need to be assigned some.

**June 16, 2015**

Who'd have thought that FE7 reverse recruitment to be the most difficult one to create? Many classes don't exist (especially female versions) and we have two versions of the game to use as a basis. I ended up using Hector Mode as the base (since it has all characters).

**June 15, 2015**

Made initial commit with FE7 game data partially populated.

**June 14, 2015**

*Beta Release* - FE6 should be fully functional and ready for beta testing. The only issues known are the ballistas on nomads/warriors graphical glitch (likely won't fix) and every so often, Miledy's script in Ch. 2 causes a hard lock (will have to fix if consistently reproducible (seems to happen randomly for me)).

**June 13, 2015**

Added a Support Manager to handle re-mapping of support conversations when the recruitment order is modified.

Fixed the logic for assigning lord status to a single character instead of a class (why the game doesn't do this to begin with is beyond me).

Added logic for buffing enemies. Should be generic enough to work across all games.

Removed Random affinity bonuses because it just doesn't seem that fun to buff them and it only makes things significantly easier.

Added the ability to specify CON variance as well.

Did a first pass at Reverse Recruitment. Mostly works, though there's some minor issues. Chapter 3's orphanage scene is glitched and causes a hard lock when the children run out with the bishop. This can be skipped, but it also causes a rogue child NPC standing outside of the orphanage afterwards. Secondly, there's a high chance of the randomizer freezing when doing this because some combinations of assignments won't work towards the end when the remaining choices are all labeled as invalid due to being unable to fill some conditions. Will have to work out some better logic for randomly assigning recruitment.

**June 12, 2015**

Added logic to demote and delevel units as necessary. Need to figure out some better deleveling logic because RR Karel starts with straight 0s and 1 HP with his growths. Meanwhile, crappy growth characters like Niime and Yodel barely have any stats taken off. There's also the problem of needing to repoint DQs and support IDs since the characters have their IDs changed.

Added a Quote Manager to handle re-mapping death quotes when recruitment order is reversed. Also updated deleveling to be more harsh (assuming level 20 demotions instead of 10) and added a baseline of stats (8 HP, 2 STR, and 5 SKL).

**June 11, 2015**

Finished up a first pass at Reverse Recruitment. Characters have not been leveled (or rather de-leveled) properly yet, so the game is hilariously broken. Will figure out a way of de-leveling next (probably just the reverse of leveling, i.e. growths become a chance to stat down instead of up).

**June 10, 2015**

Created Repository and Initial Check-in of code. Basic functionality works for all games (randomizing growths, bases, CON, MOV, affinities, and items). Random classes only works with FE6 at the moment. Working through issues with FE6 classes.

Fixed an issue where unpromoted female classes were not being randomized

Added Miledy to the blacklist for random classes. Her scripted flying sections cause the game to lock up if she's randomized into a class that can't fly.

Fixed an issue where weapons randomized to have an effectiveness pointer or a stat boost pointer were not being written back to the file.

Reproduced the freezing issue when breaking weapons. Only seems like a problem in v1.0 of the patch though. Will need further investigation.

Fixed an issue where non-weapon items were being given random traits if the traits option was turned on.

Removed Uncounterable from the list of possible traits for weapons in FE6, due to animation lockups when applying to melee weapons.

Fixed an issue where the first item of each table was important data that was being overwritten. This fixes the locking issues in the Redux translation patch v1.0.

## Purpose
The intent for this project was to create an easy-to-use and customizable randomizer for use with the Fire Emblem games for Game Boy Advance. This includes Fire Emblem: Sword of Seals (JP), Fire Emblem (NA), and Fire Emblem: The Sacred Stones (NA). This application simply reads the game data (from a *.gba file) and directly modifies the bytes in the data tables to generate a version of the game that may contains randomized classes, growths, items, and so on. 

### FE6 Notes

* My testing has been using the redux translation patch. I don't know how well it works with other patches (or even unpatched), so I recommend you use the same patch. All issues with v1.0 of the redux translation patch have been ironed out at this point, I think. You can find the Redux translation patch (both 1.0 and older versions) here: http://serenesforest.net/forums/index.php?showtopic=41095
* The "Uncounterable" trait, which is usually reserved for siege tomes, has been removed from the pool of possible weapon traits that can be randomized, due to the game assuming that it is indeed a siege tome, and animating from 3+ spaces away, causing melee weapons to lock up.
* Something that's interesting: Bosses randomized as thieves will move off of the throne to steal stuff. Not going to try to fix that one (short of not giving bosses the thief class).
* For Reverse Recruitment, the randomizer will use the same random starting inventory algorithm as when randomizing classes. I assume most patches for reverse recruitment hard code in an inventory for each person. I can add an option to do so as well, if random starting inventories are not desirable.
* Note that, for random and reverse recruitment, characters were swapped wholesale. This means their death quotes and support conversations remain intact, but who is used to talk to who has not been updated (makes sense, since you can't get Roy to talk to somebody if Roy hasn't joined yet). So you'll have to remember who certain characters are to recruit people (for example, whoever replaces Clarine has to talk to whoever replaces Klein to recruit him), but whenever you get Clarine and Klein, they can still support each other (even starting from Chapter 1 if they randomly joined then).
* When deleveling and demoting characters for reverse and random recruitment, their growths are used to determine how many stats they lose (and may not be balanced initially). Characters with low growth (Niime, Yodel, etc.) will barely lose any stats even after losing a lot of levels, which makes them particularly strong at the start. But remember, their growths are terrible, so I figure it's a tradeoff for being so powerful early on. Think of them as unpromoted Jeigans if they join early.
* When demoting a character, I assume they promoted at level 10 for the purpose of delevling their stats to reasonable levels. As such, they'll be a bit better than normal if they promote at level 20 (though only slightly, with their growths).
* If lords are randomized, Lords can promote with the Knight's Crest. Soldiers can also now promote to General with the Knight's Crest.

### FE7 Notes

* It's likely I'll ask for you to avoid Lyn Normal mode for the time being due to the tutorial likely to be screwed by any modifications. Lyn Hard mode should be ok though (as long as the tutorial is off). The other option is that the randomizer automatically applies a tutorial killer patch or something. **EDIT: The randomizer now does this for you. FE7 will be auto-patched with ~~Blazer's tutorial killer~~ Arch's Tutorial Slayer. Won't stop all issues with Lyn mode, but it might give you a chance of playing through it. Don't ask me how stats will transfer, I have no idea.**
* By default, all classes that don't naturally show up in the game are removed from the pool when randomizing classes. That is, a large chunk of female classes (thief, mercenary, myrmidon, cavalier, nomad, wyvern knight, shaman, and armor knight, I think) will not show up. I'd rather things work well, then deal with glitches.
* Figuring out mappings for reverse recruitment is a bit difficult due to a high chance of Isadora and Vaida getting demoted into classes that may be buggy. We'll roll with it for now and see how badly it breaks. **EDIT: I've settled for using Hector mode as the basis for reverse recruitment (with slight modifications for less issues).**
* Need a solution for Athos in Reverse Recruitment, as he starts with no stats, and in a unique class that can't promote. Will probably have to create a special class for him.
* Soldiers can promote with the use of Knight's Crest. If lords are randomized, they can also promote with Knight's Crest (Lyn with Hero's Crest).

### FE8 Notes

* Preliminary research seems to indicate that trainees promoting at level 10 are hardcoded to the character. This means that if anybody but Ross, Amelia, or Ewan gets stuck with a trainee class, they're stuck. At the same time (and more notably), regardless of the class Ross, Amelia, and Ewan get, they will get a forced level 10 promotion. As far as I know, no patch exists to fix this. I did some digging in the ASM with no luck, so this may have to stay like this. :(
* While Trainee classes are kind of unfortunate, Trainee (2) classes should be ok, since they act like regular unpromoted classes (i.e. max level 20). So basically, if Ross, Ewan, or Amelia get trainee classes, they will start with the Trainee (1) class, while everybody else will get the Trainee (2) variant. Promoted units, if they get trainee classes, will get the Super Trainee version.
* Monsters promote with items that fit the monster. The list is:
  * **Guiding Ring**: Mogalls > Arch Mogalls
  * **Hero Crest**: Revenant > Entombed, Bonewalker > Wight, Mauthe doog > Gwyllgi
  * **Knight Crest**: Bael > Elder Bael, Tarvos > Maelduin
  * **Orion's Bolt**: Bow Bonewalker > Bow Wight
  * **Elysian Whip**: Gargoyle > Deathgoyle

## Future Plans

The remaining feature list (which you can get a sneak peek at with the app) is as follows:

* Option to Randomize regular enemies
* Attempt to un-messify color palettes for randomized classes.
* Maybe try to get faces consistent in cutscenes when modifying recruitment.

I still need to implement a Mac version which will be written in Objective-C later. If there is demand for a Linux version, I'll do that after Mac.
