using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape = new Hexagon();

            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(shape);
        }
    }
}
