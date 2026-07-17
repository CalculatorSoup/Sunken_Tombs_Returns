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

