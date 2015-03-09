using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wanderer.Utility
{
    struct Int2
    {
        public int x;
        public int y;

        public Int2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Int2 operator -(Int2 first, Int2 other)
        {
            return new Int2(first.x - other.x, first.y - other.y);
        }

        public static Int2 operator +(Int2 first, Int2 other)
        {
            return new Int2(first.x + other.x, first.y + other.y);
        }

        public static Int2 operator *(Int2 vec, float scalar)
        {
            return new Int2((int)(vec.x * scalar), (int)(vec.y * scalar));
        }

        public static Int2 operator /(Int2 vec, float scalar)
        {
            return new Int2((int)(vec.x / scalar), (int)(vec.y / scalar));
        }

        public double LengthSquared { get { return x * x + y * y; } }
        public double Length { get { return Math.Sqrt(x * x + y * y); } }
    }

    struct Float2
    {
        public float x, y;
        public Float2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Float2 operator -(Float2 first, Float2 other)
        {
            return new Float2(first.x - other.x, first.y - other.y);
        }

        public static Float2 operator +(Float2 first, Float2 other)
        {
            return new Float2(first.x + other.x, first.y + other.y);
        }

        public static Float2 operator *(Float2 vec, float scalar)
        {
            return new Float2(vec.x * scalar, vec.y * scalar);
        }

        public static Float2 operator /(Float2 vec, float scalar)
        {
            return new Float2(vec.x / scalar, vec.y / scalar);
        }

        public double LengthSquared { get { return x * x + y * y; } }
        public double Length { get { return Math.Sqrt(x * x + y * y); } }
    }


}