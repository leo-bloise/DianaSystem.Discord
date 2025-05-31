using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Collections;

namespace DianaSystem.AnimationGenerator
{
    public class SpriteSheet : IEnumerator<Image>, IDisposable
    {
        private int _frameWidth;
        private int _frameHeight;
        private int _totalFrames;
        private Image _image;
        private int _currentFrameIndex = 0;
        public int Width => _frameWidth;
        public int Height => _frameHeight;
        public SpriteSheet(Image image)
        {
            Load(image);
        }
        public Image Current => CurrentFrame();
        object IEnumerator.Current => Current;
        public void Dispose() 
        {
            _image.Dispose();
        }
        public bool MoveNext()
        {
            _currentFrameIndex++;
            return _currentFrameIndex < _totalFrames;
        }
        public void Reset()
        {
            _currentFrameIndex = 0;
        }
        private Image CurrentFrame()
        {
            Rectangle sourceRect = new Rectangle(_currentFrameIndex * _frameWidth, 0, _frameWidth, _frameHeight);
            return _image.Clone(ctx => ctx.Crop(sourceRect));
        }
        private void Load(Image image)
        {
            int height = image.Height;
            int width = height;
            _totalFrames = image.Width / width;
            _frameHeight = height;
            _frameWidth = width;
            _image = image;
        }
    }
}
