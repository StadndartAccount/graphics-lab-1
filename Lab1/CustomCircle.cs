using System;
using SFML.Graphics;
using SFML.System;

namespace Lab1
{
    public class CustomCircle
    {
        public CircleShape circle { get; private set; } = new CircleShape();
        private float speed = 1;
        private float resizingSpeed = 1;

        public int radiusDirection = 1;
        public float yDirection = 1;
        public float xDirection = 1;
        
        public int minRadius { get; }
        public int maxRadius { get; }
        public float currentRadius
        { 
            get {
                return circle.Radius;
            }
            set
            {
                circle.Radius = value;
            }
        }

        public Vector2f currentPosition
        {
            get
            {
                return circle.Position;
            }
            set
            {
                circle.Position = value;
            }
        }

        public CustomCircle()
        {
            Random rand = new Random();
            minRadius = rand.Next(1, 20);
            maxRadius = rand.Next(40, 50);
            currentRadius = rand.Next(minRadius, maxRadius);

            xDirection = (float)rand.NextDouble();
            yDirection = (float)rand.NextDouble();

            speed = rand.Next(1, 20) * (float)rand.NextDouble();
            resizingSpeed = (maxRadius - minRadius) / 20;

            circle.FillColor = new Color((byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255));
            circle.OutlineThickness = rand.Next(1, 5);
            circle.Position = new Vector2f(rand.Next(100, 300), rand.Next(50, 400));
            circle.OutlineColor = new Color((byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255));

        }

        public void ChangeRadius()
        {
            currentRadius += radiusDirection * resizingSpeed;
        }

        public void ChangePosition()
        {
            Random rand = new Random();
            currentPosition += new Vector2f(xDirection * (float)rand.NextDouble(), yDirection * (float)rand.NextDouble()) * speed;
        }
    }
}
