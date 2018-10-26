# Handling Input!

**Make sure you read the getting started page before this one! it can be found [here](../README.md#getting-started)**

All input handling is done in the player class, by using the `KeyInput` object available there.
```csharp
// In Player Update Method
if(KeyInput.IsPressed(Keys.Right)) {
  PosX++;
}
```
The code above will move the player right (by increasing the x value) as long as the right arrow key is pressed.

-----------
The `KeyInput` object has 4 important methods:

* `IsPressed` - returns true if the key is currently pressed down.
* `IsReleased` - returns true if the key is currently not pressed down.
* `JustPressed` - returns true for one tick after the key has been pressed.
* `JustReleased` - returns true for one tick after the key has been released.
