using System;
using D2Map.Core.Models;

namespace D2Map.Core.Extensions;

public static class MathExtensions
{
    public static PointX Subtract(this PointX point, PointX offset) => point.Subtract(offset.X, offset.Y);

    public static PointX Subtract(this PointX point, int x, int y)
    {
        return new PointX(point.X - x, point.Y - y);
    }

    public static float Angle(this PointX point)
    {
        return (float)Math.Atan2(point.Y, point.X);
    }
}