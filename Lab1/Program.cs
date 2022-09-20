using SFML.Graphics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow renderWindow = new RenderWindow(new SFML.Window.VideoMode(640, 320), "Test");
            renderWindow.SetVerticalSyncEnabled(true);

            while(renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();

                renderWindow.Clear(Color.Black);

                renderWindow.Display();
            }
        }
    }
}
