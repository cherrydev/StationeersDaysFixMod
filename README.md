# DaysFixMod

This mod restores the days counter and re-enables storms.

## Installation

- If you're playing the beta version of Stationeers, make sure you use the latest beta branch version listed on the full [releases](https://github.com/cherrydev/StationeersDaysFixMod/releases) page.
- First [install BepInEx](https://github.com/jixxed/StationeersMods) the same as how StationeersMod directs it. You do not need to install StationeersMod.
- Unzip the [release archive](https://github.com/cherrydev/StationeersDaysFixMod/releases/latest) into the `BepInEx\plugins\` directory.

## Dedicated Server & Multiplayer

This mod supports multiplayer and dedicated server. All clients and the server need to have it installed. Installation on a dedicated
server is identical.

## Custom Worlds / Scenarios

If you are not playing one of the standard scenarios, you may notice a problem where the day will not start
at 0. The first time you play a custom scenario, a config entry will be made in `BepInEx\config\DaysFix.cfg`
in the section called `[DayOffsets]` with the name of the world/scenario as the key and a default value of 0. 
Use the value of the first day that you see displayed in the F3 console when the world first loads up. For
example, Vulcan is 266.

## Notes

The original implementation of the day counting attempts to calculate a solar day by using the orbital simulation, but does not
quite get it right. Another side effect is the sun skipping around in the sky on some planets. This patch uses a sidereal day
instead of a solar day, which the game does calculate correctly. This means the day counter will drift by one day per year.

If you implement a custom world that has a celestial time offset, it may show a day other than 0 for the first day. If it's greater than
a week you may end up with a storm on your first day. You can add it to the `ScenarioOffsets` dictionary in `DaysFixModPatch.cs`.

## Release notes

- v0.0.3  03/07/2024 Configurable for custom worlds. Works for release and beta branch
- v0.0.2-beta Initial release for beta branch
- v0.0.2 - Initial release
