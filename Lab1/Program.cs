using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLoop();

        }

        static void MainLoop()
        {
            RenderWindow renderWindow = new RenderWindow(new SFML.Window.VideoMode(640, 640), "Test");
            renderWindow.SetVerticalSyncEnabled(true);

            uint windowWidth = renderWindow.Size.X;
            uint windowHeight = renderWindow.Size.Y;


            List<CustomCircle> circlesList = new List<CustomCircle>();

            for (int i = 0; i < 20; i++)
            {
                circlesList.Add(new CustomCircle());
            }

            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();

                renderWindow.Clear(Color.Black);

                foreach (CustomCircle circle in circlesList)
                {
                    Random rand = new Random();

                    FloatRect bound = circle.circle.GetLocalBounds();
                    circle.circle.Origin = new Vector2f(bound.Width / 2, bound.Height / 2);


                    if (circle.currentRadius > circle.maxRadius && circle.radiusDirection > 0 || circle.currentRadius < circle.minRadius && circle.radiusDirection < 0)
                    {
                        circle.radiusDirection *= -1;
                    }


                    if (circle.currentPosition.X - circle.currentRadius < 0 || circle.currentPosition.X + circle.currentRadius > windowWidth)
                    {
                        circle.xDirection = -Math.Sign(circle.xDirection) * (float)rand.NextDouble();
                    }

                    if (circle.currentPosition.Y - circle.currentRadius < 0 || circle.currentPosition.Y + circle.currentRadius > windowHeight)
                    {
                        circle.yDirection = -Math.Sign(circle.yDirection) * (float)rand.NextDouble();
                    }


                    circle.ChangePosition();
                    circle.ChangeRadius();
                    renderWindow.Draw(circle.circle);
                }

                renderWindow.Display();
            }
        }
    }
}
