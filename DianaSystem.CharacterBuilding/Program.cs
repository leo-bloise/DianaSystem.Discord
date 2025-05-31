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
