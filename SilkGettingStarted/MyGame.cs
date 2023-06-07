using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace SilkGettingStarted
{
    public class MyGame
    {
        IWindow window;
        GL? Gl;

        public MyGame()
        {
            window = Window.Create(WindowOptions.Default with
            {
                Title = "Hello World!",
                
            });

            window.Render += Window_Render;
            window.Load += Window_Load;

            window.Initialize();

            IInputContext inputContext = window.CreateInput();

            foreach(var keyCap in inputContext.Keyboards)
            {
                keyCap.KeyDown += KeyCap_KeyDown;
            }
        }

        private void KeyCap_KeyDown(IKeyboard arg1, Key arg2, int arg3)
        {
            Console.WriteLine(arg2);
        }

        public void Start()
        {
            window.Run();
        }
        private void Window_Load()
        {
            Gl = window.CreateOpenGL();
        }

        private void Window_Render(double obj)
        {
            Gl?.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
            Gl?.Clear(ClearBufferMask.ColorBufferBit);
        }

        
    }
}
