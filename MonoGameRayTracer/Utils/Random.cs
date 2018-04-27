﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameRayTracer
{
    public static class Random
    {
        private static System.Random m_random = new Pcg.PcgRandom(DateTime.Now.Millisecond);

        public static float Value => (float)m_random.NextDouble();

        public static Vector3 Vector3 => new Vector3(Value, Value, Value);
        public static Vector3 Vector3Twice => new Vector3(Value * Value, Value * Value, Value * Value);
        public static Color Color => new Color(Value, Value, Value);
    }
}
