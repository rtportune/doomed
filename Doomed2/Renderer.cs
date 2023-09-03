using Doomed;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Point = System.Windows.Point;

namespace Doomed2
{
    public class Renderer
    {
        private const int RaysPerFOVDegree = 3;
        private const double ViewDistance = 20d;
        public RectangleF RenderResolution { get; set; }

        public void Draw(Graphics context, Player player, Map map)
        {
            if (RenderResolution.IsEmpty) return;

            //First, fill the background
            context.FillRectangle(Brushes.LightBlue, RenderResolution);

            var segmentWidth = RenderResolution.Width / (RaysPerFOVDegree * player.FOV);

            //divide each degree of the player's FOV and cast a ray 
            for (int ray = 0; ray < RaysPerFOVDegree * player.FOV; ray++)
            {
                var rayAngle = player.Heading + ((double)ray / (RaysPerFOVDegree * player.FOV)  * player.FOV) - player.FOV / 2;
                var rayDirection = new Vector(Math.Cos(rayAngle * Math.PI / 180), Math.Sin(rayAngle * Math.PI / 180));
                rayDirection.Normalize();

                foreach (var wall in map.Walls)
                {
                    var distanceToWall = GetRayToLineSegmentIntersection(player.Position, rayDirection, wall.startPoint, wall.endPoint);

                    if (distanceToWall != null)
                    {
                        var wallHeight = RenderResolution.Height * (ViewDistance - distanceToWall.Value) / ViewDistance;

                        var wallRect = new RectangleF(ray * segmentWidth, (RenderResolution.Height / 2) - ((float)wallHeight / 2), segmentWidth, (float)wallHeight);

                        context.FillRectangle(Brushes.Red, wallRect);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the distance from the ray origin to the intersection point or null if there is no intersection.
        /// </summary>
        public double? GetRayToLineSegmentIntersection(Point rayOrigin, Vector rayDirection, Point point1, Point point2)
        {
            var v1 = rayOrigin - point1;
            var v2 = point2 - point1;
            var v3 = new Vector(-rayDirection.Y, rayDirection.X);

            var dot = v2 * v3;
            if (Math.Abs(dot) < 0.000001)
                return null;

            var t1 = Vector.CrossProduct(v2, v1) / dot;
            var t2 = (v1 * v3) / dot;

            if (t1 >= 0.0 && (t2 >= 0.0 && t2 <= 1.0))
                return t1;

            return null;
        }

    }
}
