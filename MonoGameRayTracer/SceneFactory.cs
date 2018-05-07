﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameRayTracer.Materials;
using MonoGameRayTracer.Primitives;
using MonoGameRayTracer.Textures;
using System.Collections.Generic;

namespace MonoGameRayTracer
{
    public static class SceneFactory
    {
        public static List<Hitable> MakeSphereScene(ContentManager content, int sceneComplexity)
        {
            var list = new List<Hitable>();
            list.Add(new Sphere(new Vector3(0, -1000, 0), 1000, new LambertMaterial(new CheckerTexture())));
            
            var temp = new Vector3(4, 0.2f, 0);

            for (var a = -sceneComplexity; a < sceneComplexity; a++)
            {
                for (var b = -sceneComplexity; b < sceneComplexity; b++)
                {
                    var chooseMat = Random.Value;
                    var center = new Vector3(a + 0.9f + Random.Value, 0.2f, b + 0.9f + Random.Value);

                    if ((center - temp).Length() > 0.9f)
                    {
                        if (chooseMat < 0.8f)
                            list.Add(new Sphere(center, 0.2f, new LambertMaterial(Random.Vector3Twice)));
                        else if (chooseMat < 0.95f)
                            list.Add(new Sphere(center, 0.2f, new MetalMaterial(0.5f * (1 + Random.Value), 0.5f * (1 + Random.Value), 0.5f * (1 + Random.Value), 0.5f * Random.Value)));
                        else
                            list.Add(new Sphere(center, 0.2f, new MetalMaterial(0.5f * (1 + Random.Value), 0.5f * (1 + Random.Value), 0.5f * (1 + Random.Value), 0.5f * Random.Value)));
                    }
                }
            }

            var earthTexture = content.Load<Texture2D>("earth");

            list.Add(new Sphere(new Vector3(0, 1, -2), 1, new LambertMaterial(new ImageTexture(earthTexture))));
            list.Add(new Sphere(new Vector3(-4, 1, 0), 1, new LambertMaterial(new NoiseTexture())));
            list.Add(new Sphere(new Vector3(4, 1, 0), 1, new MetalMaterial(0.7f, 0.6f, 0.5f, 0.0f)));
            //list.Add(new Cube(new Vector3(0, 0, 1), new Vector3(1, 1, 2), new LambertMaterial(new NoiseTexture())));
            
            //var mesh = new Mesh(content.Load<Model>("Ship"), new MetalMaterial(0.7f, 0.6f, 0.5f, 0.0f));
            //list.Add(mesh);

            return list;
        }

        public static List<Hitable> MakeCornellBoxScene()
        {
            var list = new List<Hitable>();

            var red = new LambertMaterial(new Vector3(0.65f, 0.05f, 0.05f));
            var white = new LambertMaterial(new Vector3(0.73f, 0.73f, 0.73f));
            var green = new LambertMaterial(new Vector3(0.12f, 0.45f, 0.15f));
            var light = new DiffuseLightMaterial(new ConstantTexture(new Vector3(15, 15, 15)));

            list.Add(new Quad(Quad.Axis.YZ, true, 0, 555, 0, 555, 555, green));
            list.Add(new Quad(Quad.Axis.YZ, false, 0, 555, 0, 555, 0, red));
            list.Add(new Quad(Quad.Axis.XZ, false, 213, 343, 227, 332, 554, light));
            list.Add(new Quad(Quad.Axis.XZ, true, 0, 555, 0, 555, 555, white));
            list.Add(new Quad(Quad.Axis.XZ, false, 0, 555, 0, 555, 0, white));
            list.Add(new Quad(Quad.Axis.XY, true, 0, 555, 0, 555, 555, white));

            return list;
        }
    }
}
