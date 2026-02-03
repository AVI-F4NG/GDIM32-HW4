# HW4
## Devlog
### MVC Pattern Implementation
#### Control: Player

- Reads input (e.g., Space key) and triggers gameplay action via Flap(). 

- Applies gameplay effects (adds upward force to its Rigidbody2D in Flap()). 

- Detects gameplay outcomes: scoring in OnTriggerExit2D (PassZone trigger, point gained); losing in OnCollisionEnter2D (Pipe collision, _gameRuns = false)

- Broadcasts outcomes without knowing who responds, via events Flapped, Scored(int points), and GameEnded

The Player script decides when things should happen, but not how UI and audio respond.

#### View: UIUpdater and AudioUpdater

The view responsibilities are in classes that react to the controller and present feedback:

- UIUpdater: listens to Player.PointsChanged and updates _pointsText.text, and listens to Player.GameEnded to show the "game over" UI object.

- AudioUpdater: listens to Player.Flapped, Player.Scored, and Player.GameEnded, and plays the matching audio clips.

These scripts never need to know how points are earned or when game-over happens; they only display feedback when notified.

### How the code is decoupled

#### Events and decoupling

The Player (controller) publishes signals (Flapped, Scored, GameEnded, PointsChanged) at the moment gameplay state changes.

The view scripts subscribe (+=) to those events and react locally. This prevents tight coupling like "Player directly calls UIUpdater.UpdatePoints()", preventing the player from directly controlling what the "view" scripts should do. Instead, Player just raises Scored?.Invoke(_points) (conceptually), and any number of systems can respond.

#### Singleton (Locator) and decoupling

The Locator singleton acts as a shared access point for dependencies, so the view/control scripts don’t need hard references to each other: there is no need for the view scripts to create instances of Player. UIUpdater and AudioUpdater can retrieve the player reference using Locator.Instance.Player. Pipes and spawners can also grab Locator.Instance.Player and subscribe to GameEnded. So lookup is centralized in Locator, and systems are decoupled because they connect through events instead of direct method calls.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites