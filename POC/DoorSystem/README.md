**Origin POC Requirements:** Implement door system.
- Given a character position x, y. Tell me the closest door. (Optional)
- Open(doorId) and Close(doorId).
- Register(doorId, scenId). Open(scenId), Close(scenId) will close and open all doors registered under scene.
- Autopen door, when a user approaches a door that door only should open.
- The locked door should return false if you call canOpen(doorId, keyId). And users can hold multiple keys. A master key should be able to open all rooms.

**Implemented POC:** Implement door system.
- Open(doorID).
- Auto open door.
- Locked door, collect key, use key to open a door.

**Resources:**
- [Observer Pattern: Approach Door to Open (8m)](https://youtu.be/gx0Lt4tCDE0)
- [Create RPG without Code - Unity RPG Creator Kit (24m)](https://youtu.be/wnzJ06Y8mdg)