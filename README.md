# DaysFixMod

This mod restores the days counter and re-enables storms.

## Installation

- If you're playing the beta version of Stationeers, make sure you use the latest beta branch version listed on the full [releases](https://github.com/cherrydev/StationeersDaysFixMod/releases) page.
- First [install BepInEx](https://github.com/jixxed/StationeersMods) the same as how StationeersMod directs it. You do not need to install StationeersMod.
- Unzip the [release archive](https://github.com/cherrydev/StationeersDaysFixMod/releases/latest) into the `BepInEx\plugins\` directory.

## Dedicated Server & Multiplayer

This mod supports multiplayer and dedicated server. All clients and the server need to have it installed. Installation on a dedicated
server is identical.

## Notes

The original implementation of the day counting attempts to calculate a solar day by using the orbital simulation, but does not
quite get it right. Another side effect is the sun skipping around in the sky on some planets. This patch uses a sidereal day
instead of a solar day, which the game does calculate correctly. This means the day counter will drift by one day per year.

If you implement a custom world that has a celestial time offset, it may show a day other than 0 for the first day. If it's greater than
a week you may end up with a storm on your first day. You can add it to the `ScenarioOffsets` dictionary in `DaysFixModPatch.cs`.
