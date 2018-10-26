# RedGameEngine
A game engine made for simple C# game making!

### Getting Started
##### Adding the dll:
A download for the dll file can be found [here]().

After you download it, create a Windows forms app project and add a reference to the dll `(Right click project > Add > Reference > Browse)`.

##### Creating the engine
In your form class, declare a new member of type `GameEngine`, and initiate it in the form_load method, passing in the form as `this` (and optional `width` and `height`)
```csharp
public partial class Form1 : Form {
    private GameEngine engine;

    public void Form1_Load(object sender, EventArgs args) {
        engine = new GameEngine(this, width=500, height=500);
    }
}
```

This will register all the things needed and make your form ready for use.
##### Adding the player
In order to use the engine, it must contain a player. A player is a few things.

First of all, its an entity on the screen, which means it has an `PosX` and a `PosY`.

As well as that, the player has access to the key and mouse (soon) listener. meaning input handling goes through him.

And finally, all interactions with other entities go through him. (Maybe will be changed so that all entities can interact with other entities).

-----------
To make a player, we will need to make a class which extends the `RedGameEngine.World.WorldPlayer` class. This class is abstract and will require you to implement an `Update()` method, which is called every tick (60 times per second).

```csharp
using RedGameEngine.World;
public class MyPlayer : WorldPlayer {

  public override void Update() {
    PosX++; // Move left
  }

}
```
Now that we have our player class, all we need to do is make an instance of it and pass it to the engine!
```csharp
MyPlayer p = new MyPlayer();
engine.SetPlayer(p);
```

##### Let's go!
Now all that's left is to call `engine.Start()!` this will make the tick-render loop start!

if you followed everything correctly you should have a green rectangle moving on the screen!

### More Advanced Tutorials
**Can be found here:**

[Handing Input](tutorials/Tutorial-Input.md) - How to use the key and mouse(TBA) listeners!

[Entities and interactions]() - How to add more entities and make them interact with the player!
