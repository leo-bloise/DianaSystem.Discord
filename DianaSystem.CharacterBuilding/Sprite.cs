using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections;

namespace DianaSystem.AnimationGenerator
{
    public class Sprite : IEnumerable<Image>, IDisposable
    {
        private SpriteSheet _spriteSheet;
        public Sprite(string filepath)
        {
            ValidateFilepath(filepath);
            _spriteSheet = new SpriteSheet(Image.Load(filepath));
        }
        public void Dispose()
        {
            _spriteSheet.Dispose();
        }
        public IEnumerator<Image> GetEnumerator()
        {
            return _spriteSheet;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void ValidateFilepath(string filepath)
        {
            if (Directory.Exists(filepath))
            {
                throw new Exception($"filepath {filepath} must be a file");
            }
            if(!File.Exists(filepath))
            {
                throw new Exception($"filepath must be a file and it must exists");
            }
            if(Path.GetExtension(filepath) != ".png")
            {
                throw new Exception("only png files are supported");
            }
        }
        public Image<Rgba32> ToGif()
        {
            Image<Rgba32>? gif = null;

            foreach (var spriteFrame in this)
            {
                using(spriteFrame)
                {
                    Image<Rgba32> frame = spriteFrame.CloneAs<Rgba32>();
                    GifFrameMetadata metadata = frame.Frames.RootFrame.Metadata.GetGifMetadata();
                    metadata.FrameDelay = 5;
                    metadata.DisposalMethod = GifDisposalMethod.RestoreToBackground;

                    if (gif == null)
                    {
                        gif = frame;
                        gif.Metadata.GetGifMetadata().RepeatCount = 0;
                        continue;
                    }
                    gif.Frames.AddFrame(frame.Frames.RootFrame);
                }
            }

            return gif!;
        }
    }
}
