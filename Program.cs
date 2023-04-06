using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            //Original example set.
            List<ColorChip> colorChips = new List<ColorChip>
            {                               
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple)
            };

            //Another example set.
            /*List<ColorChip> colorChips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Red),
                new ColorChip(Color.Red, Color.Orange),
                new ColorChip(Color.Orange, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Purple),
                new ColorChip(Color.Purple, Color.Red),
                new ColorChip(Color.Red, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Red, Color.Purple),
                new ColorChip(Color.Purple, Color.Yellow),
                new ColorChip(Color.Yellow, Color.Orange),
                new ColorChip(Color.Orange, Color.Purple),
                new ColorChip(Color.Purple, Color.Orange),
                new ColorChip(Color.Orange, Color.Red),
                new ColorChip(Color.Red, Color.Green)
            };*/

            Console.WriteLine("Here is the set of color chips you currently have:");

            foreach (var colorChip in colorChips)
            {
                Console.WriteLine(colorChip);
            }

            Console.Write("\n");

            var resultList = new List<ColorChip>();

            int blueIndex = colorChips.FindIndex(item => item.StartColor.ToString() == "Blue");
            int greenIndex = colorChips.FindIndex(item => item.EndColor.ToString() == "Green");

            if (blueIndex < 0)
            {
                Console.WriteLine("No chip has blue as the first color!");
                Console.WriteLine(Constants.ErrorMessage);
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (greenIndex < 0)
            {
                Console.WriteLine("No chip has green as the second color!");
                Console.WriteLine(Constants.ErrorMessage);
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("From blue to green, here is how the chips can be connected:");

            for (int i = 0; i < colorChips.Count; i++)
            {
                if (colorChips[i].StartColor.ToString() == "Blue")
                {
                    resultList.Insert(0, colorChips[i]);
                    sb.AppendLine(colorChips[i].ToString());
                    colorChips.RemoveAt(i);
                }
            }

            int resultIndex = -1;

            while (resultIndex < 0)
            {
                for (int i = 0; i < resultList.Count; i++)
                {
                    for (int j = 0; j < colorChips.Count; j++)
                    {
                        if (resultList[i].EndColor == colorChips[j].StartColor)
                        {
                            resultList.Insert(i + 1, colorChips[j]);
                            sb.AppendLine(colorChips[j].ToString());
                            colorChips.RemoveAt(j);
                            break;
                        }
                    }
                }

                resultIndex = resultList.FindIndex(item => item.EndColor.ToString() == "Green");
                continue;
            }

            if (resultIndex < 0)
            {
                Console.WriteLine(Constants.ErrorMessage);
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
