using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamble file = new File("name11", 200, 4000);
            IStreamble image = new Image(210, 400000);

            StreamProgressInfo streamProgressInfoAboutFile = new StreamProgressInfo(file);
            StreamProgressInfo streamProgressInfoAboutImage = new StreamProgressInfo(image);

            Console.WriteLine(streamProgressInfoAboutFile.CalculateCurrentPercent());
            Console.WriteLine(streamProgressInfoAboutImage.CalculateCurrentPercent());
        }
    }
}
