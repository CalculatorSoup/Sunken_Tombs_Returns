# 1.3.0
* **Final(?) art pass:**
  * Retextured all building textures (brick, trims, tiles, and cobble) and edited textures for foliage and the Monster Cage. The building textures especially should no longer look like I drew them with crayons. lol
  * Edited the stage's fog: Underwater sections now have noticeable bluish fog. Above water, fog is brighter and extends further into the skybox to make background elements stand out a bit better. Overall the map's color palette should be closer to its appearance in Risk of Rain Returns
    * The map's sun intensity was lowered (3 -> 2.5) to compensate for the brighter fog, but the stage is overall a scosche brighter than last version
  * Remodeled the spear-wielding Lemurian statues. They no longer look like PS2 models, but humanoid models are not my specialty, so apologies if they're still a bit crusty,,
  * Added an inset area to the L-shaped building on the surface
  * Slightly reduced bloom intensity
  * Slightly improved the water caustics' visuals
* **Monster Cage changes:**
  * Interactable:
    * Increased the red light's radius, which should make it easier to spot from afar
    * Revised interact prompt
  * Legendary Reward:
    * Extra Legendary drops from Sale Stars no longer scale with player count. No fun allowed. Sorry (but I also added a config option to revert this change. Fun allowed)
  * Boss:
    * Acrid now prioritizes players
    * Acrid should no longer try to leap away from you
    * Increased base damage (15 -> 30) and scaling damage (3 -> 6)
    * Removed passive health regen
      * Overall, Acrid should be more aggressive and should now focus on players over drones and other allies. I considered lowering its health but wasn't sure if that was actually necessary, so I did not do that. Hopefully it's a bit more engaging to fight now. Feedback on this would be appreciated!!
* **Other changes:**
  * Revised the stage's lore - specifically, the section mentioning the Artifact of Origin
  * Rotated a geyser near the center of the map to make it clearer where it's supposed to take you
  * Starstorm 2: Added Clay Mongers and Security Chests to the stage!
  * Added Void Devastators
    * Crab
  * Removed Stone Titans
    * I only included these because I was trying to emulate the original stage's monster pool as closely as possible, but there's already 3 other base game bosses in the stage and there's already another stone enemy in the stage, so like, they really did not need to be here I think
* **Fixes:**
  * Fixed a bunch of map nodes not connecting (particularly ones activated when the central peninsula and central rock pillar variations are disabled).  Monsters and interactables should actually be able to spawn/navigate normally in those areas now
  * Patched up a couple tiny holes in the map geometry
  * Fixed blue vertical lines appearing when viewing above-water grass patches from an angle
  * Monster Cage: Fixed bonus Sale Star legendary drops spawning in a different position than the standard drop position

# 1.2.1
* **Fixes:**
  * Hopefully fixed an issue where interactables/characters would occasionally spawn on walls, introduced in the last update
  * Fixed an issue where the Simulacrum version of the stage was missing a few boulders, also introduced in the last update,,,
  * Fixed a bunch of air nodes, mostly in/around the cave, having an assigned gate when they shouldn't have
* **Changes:**
  * The cave's upper layer platforms are no longer a random variation and will instead always appear, which should fix the issue where map nodes would simply never work there for reasons that I still don't entirely understand
  * Added a couple faraway rock arches to the map's out-of-bounds terrain

# 1.2.0
* **Layout changes:**
  * The large L-shaped building's roof is now an accessible area in the map. Various launch pads were added to connect it to other areas
  * Revamped the tall cave/graveyard area. Added hills, dips, cliffs and platforms to make it less flat/empty and better utilize the vertical space
    * Relocated the Newt Altar in the cave to be very slightly more hidden
    * Raised the geyser in the cave up onto a new ledge directly above its previous location
    * Simulacrum: Replaced the additional jump pad in the cave with a vertical lift
  * Removed the giant wall/pillar in the center of the small rectangular building. Added a small inset floor in its place
  * Updated a few random variations (central pillar, peninsula, cave upper layer) to increase the size of small cliffs/platforms
  * Slightly changed the smaller L-shaped building's roof (replaced the lone 2x1 block with a rock, removed the beams in the middle of the skylights)
  * Rearranged some blocks and other objects in the large L-shaped building's interior
* **Other changes:**
  * Added red lights by the Monster Cages to help them stand out against the map's obscenely blue color palette
  * Reduced the water's distortion strength to make underwater objects easier to spot from the surface
  * Made a few changes to increase the map's brightness (increased sun intensity, added bloom, removed vignette effects)
* **Art pass:**
  * Increased the main terrain mesh's poly count in a couple spots, particularly focusing on rock columns and slopes/hills
  * Added various details to the building's interiors (inset shelves, ramps replaced with stairs, more detailed ceilings for a couple buildings)
  * Added new stalactites to the cave and other rocky ceilings where appropriate
  * Added more props: table, bubble flower, big statue, 2 statuette variants, smooth stalactites
* **Fixes:**
  * Attempted to fix map nodes never actually being used in a few spots attached to random variations (cave upper layer, underwater platforms on the peninsula and central pillar variations). Cave upper layer still doesn't work and I have literally no idea why. It sucks
  * Attempted to fix several spots where NPCs (usually Larvae or Acrid) would leap onto a cliff face and get stuck there. There's probably still spots where it can happen but hopefully I got all the most common ones
  * Fixed a couple map nodes attached to the central pillar variation that didn't have a gate name assigned, causing stuff to spawn in midair
  * Patched up a couple holes in the terrain
  * Added another LOD mesh to the sarcophagi to fix them never appearing if LOD reduction was set to the lowest value

# 1.1.1
* The Monster Cages are now Sale Star compatible :)
* Added ambient noise
* Fixed a map node that didn't have a gate assigned, causing interactables to spawn in a wall sometimes

# 1.1.0
* **Quick art pass:**
  * Increased the poly counts of various meshes:
    * Main terrain mesh: mostly walls near the center area
    * Skybox rock arches
    * Boulders and pebbles
    * Glowing coral
    * Wavy kelp clusters
    * Underwater bush
    * Monster cage
    * Logbook diorama ocean hemisphere
  * Added some extra details surrounding the above-water monster cage
  * Updated the texture for the spiky plants on the background arches and surrounding the monster cages
  * Slightly adjusted post processing
  * Increased LOD distance for the loose bricks/"boxes" around the map
  * Added a couple extra details to the logbook diorama
* **Changes/Fixes:**
  * Colossi are now disabled by default since there's a lot of relatively low ceilings and they tend to get stuck in weird spots
    * Stone Titans can now appear in the stage if Colossi are disabled in config settings
  * Disabled character spawns on some nodes in narrow hallways since Colossi could spawn stuck in them
  * Disabled character spawns near the scaffolding that connects the second floor balcony to the graveyard cave
    * This is an attempt to fix an issue where bosses could spawn inside a pillar in that area

# 1.0.2
* Increased spawn distance for Hermit Crabs (Standard -> Far)

# 1.0.1
* Fixed music not playing at all
* Fixed the monster cages not opening
* Fixed the Simulacrum variant not using its unique enemy spawn pool. It's the same but Hermit Crabs are replaced by Mini Mushrums
* Fixed the map using the same family events as Broadcast Perch. It now has its own unique set
* Moved the god rays around and made them larger
* ouuuughhhhhhh (I'm sorry)

# 1.0.0
* Initial Release

