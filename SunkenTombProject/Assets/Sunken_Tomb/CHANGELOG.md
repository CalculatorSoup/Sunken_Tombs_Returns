# 1.1.0
* Quick art pass:
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
* Changes/Fixes:
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

