using System;
using Comet.Graphics;

namespace Comet
{
    public class Path : Shape
    {
        private readonly PathF _path;
        private readonly PathScaling _scaling;

        public Path(PathF path, PathScaling scaling = PathScaling.AspectFit)
        {
            _path = path;
            _scaling = scaling;
        }

        public Path(string path, PathScaling scaling = PathScaling.AspectFit)
        {
            _path = PathBuilder.Build(path);
            _scaling = scaling;
        }

        public override PathF PathForBounds(RectangleF rect)
        {
            var bounds = _path.Bounds;
             
            AffineTransformF transform = null;

            if (_scaling == PathScaling.AspectFit)
            {
                var factorX = rect.Width / bounds.Width;
                var factorY = rect.Height / bounds.Height;
                var factor = Math.Min(factorX, factorY);
                
                var width = bounds.Width * factor;
                var height = bounds.Height * factor;
                var translateX = (rect.Width - width) / 2;
                var translateY = (rect.Height - height) / 2;
                
                transform = AffineTransformF.GetTranslateInstance(-bounds.X, -bounds.Y);
                transform.Translate(translateX, translateY);
                transform.Scale(factor, factor);
            }
            else if (_scaling == PathScaling.AspectFill)
            {
                var factorX = rect.Width / bounds.Width;
                var factorY = rect.Height / bounds.Height;
                var factor = Math.Max(factorX, factorY);
                
                var width = bounds.Width * factor;
                var height = bounds.Height * factor;
                var translateX = (rect.Width - width) / 2;
                var translateY = (rect.Height - height) / 2;
                
                transform = AffineTransformF.GetTranslateInstance(-bounds.X, -bounds.Y);
                transform.Translate(translateX, translateY);
                transform.Scale(factor, factor);
            }
            else if (_scaling == PathScaling.Fill)
            {
                var factorX = rect.Width / bounds.Width;
                var factorY = rect.Height / bounds.Height;
                transform = AffineTransformF.GetScaleInstance(factorX, factorY);

                var translateX = bounds.X * factorX;
                var translateY = bounds.Y * factorY;
                transform.Translate(translateX, translateY);
            }
            else
            {
                var width = bounds.Width;
                var height = bounds.Height;
                var translateX = (rect.Width - width) / 2;
                var translateY = (rect.Height - height) / 2;
                
                transform = AffineTransformF.GetTranslateInstance(-bounds.X, -bounds.Y);
                transform.Translate(translateX, translateY);
            }
            
            if (!transform?.IsIdentity ?? false)
                return _path.Transform(transform);

            return _path;
        }
    }
}
