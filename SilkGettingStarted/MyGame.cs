using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.Maths;

namespace SilkGettingStarted
{
    public class MyGame
    {
        static IWindow _window;
        static GL Gl;

        #region Window Specifications
        Vector2D<int> FirstScreenPosistion = new(50, 35);
        Vector2D<int> FristScreenSize = new(1800, 1000);

        Vector2D<int> SecondScreenPosistion = new(2000, 150);
        Vector2D<int> SecondScreenSize = new(1600, 900);
        #endregion


        public MyGame()
        {
            _window = Window.Create(WindowOptions.Default with
            {
                Title = "Hello World!",
                Position = SecondScreenPosistion,
                Size = SecondScreenSize,
            });

            
            _window.Load += Window_Load;
            _window.Render += Window_Render;
            _window.Update += _window_Update;

            _window.Initialize();

            IInputContext inputContext = _window.CreateInput();

            foreach(var keyCap in inputContext.Keyboards)
            {
                keyCap.KeyDown += KeyCap_KeyDown;
            }
        }
        public void Start()
        {
            _window.Run();
        }

        //Runs once when the game is loaded
        private static void Window_Load()
        {
            Gl = _window.CreateOpenGL();
            Console.WriteLine("LOAD " + DateTime.Now);
        }
        //Runs when a frame needs to be rendered
        private void Window_Render(double deltaTime)
        {
            Gl.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
            Gl.Clear(ClearBufferMask.ColorBufferBit);
            Console.WriteLine("RENDER " + DateTime.Now);
        }
        private void _window_Update(double deltaTime)
        {
            Console.WriteLine("UPDATE " + DateTime.Now);
        }
        private void KeyCap_KeyDown(IKeyboard keyReference, Key keyPressed, int keyNumber)
        {
            Console.WriteLine(keyPressed);
        }
    }
}
