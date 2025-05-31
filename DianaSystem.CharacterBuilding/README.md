# AnimationGenerator

This project was used to create some assets and produce gifs out of spritesheets. It uses `ImageSharp` to manipulate each sprite and generate a gif out of it. 

## Examples

Inside this project, you have two srpites:
- coin
- cat_idle

You can use both of them to generate a gif. For example, if we want to produce a gif of a coin, you can use the code below:
```c#
using SixLabors.ImageSharp;

namespace DianaSystem.AnimationGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(Sprite sprite = new Sprite("./assets/coin.png"))
            {
                var gif = sprite.ToGif();
                gif.SaveAsGif("coin.gif");
            }
        }
    }
}
```