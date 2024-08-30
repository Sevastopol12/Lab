using lab_3;
using System.Linq;



namespace Program
{
    internal class Point2D: Point
    {
        public float x; public float y;

        public Point2D(float x=0.0f, float y = 0.0f)
        {
            this.x = x; this.y = y;
        }
    }


    class Alpha
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Point2D> points = new List<Point2D>();

            Point2D a = new Point2D(x: 0.0f, y: 0.0f);

            points.Add(new Point2D(x: 0f, y: 0f));
            points.Add(new Point2D(x: 3f, y: 0f));
            points.Add(new Point2D(x: 0f, y: 4f));

            //// Generating points
            //for (int i = 1; i <= 7; i++)
            //{
            //    float x = (float)rnd.NextDouble();
            //    float y = (float)rnd.NextDouble();
            //    points.Add(new Point2D(x: x, y: y));
            //}

            Dictionary<string, float> distances = Cal_Distance(points);

            Display_points(points);
            Display_distance(distances);

            List<(string, string, string)> right_triangle = Right_triangle(distances);

            if (right_triangle != null)
            {
                foreach((string,string,string) item in right_triangle)
                {
                    Console.WriteLine(string.Join(" ", item));
                }
            }
            else { Console.WriteLine("No right-triangle found"); }

            Console.ReadLine();
        }





        // Display the generated points
        public static void Display_points(List<Point2D> points)
        {
            foreach (Point2D point in points) { Console.WriteLine($"{point.x} {point.y}"); }
        }



        // Display the distance for each pair of points
        public static void Display_distance(Dictionary<string, float> distances)
        {
            foreach (KeyValuePair<string, float> pair in distances)
            {
                Console.WriteLine($"Dis {pair.Key}: {pair.Value}");
            }
        }



        // Calculate the distance for each pair of points
        public static Dictionary<string, float> Cal_Distance(List<Point2D> points)
        {
            Dictionary<string, float> distances = new Dictionary<string, float>();
            Point2D p = new Point2D();

            // Nested loop
            for(int num1=0; num1<points.Count -1; num1++)
            {
                for(int num2=num1+1; num2<points.Count; num2++)
                {
                    float distance = p.cal_distance(points[num1], points[num2]);
                    distances.Add($"{num1}_{num2}", distance);
                }
            }
            return distances;
        }



        // Find right-triangle using Pythagorean theorem
        public static List<(string, string, string)> Right_triangle(Dictionary<string, float> distances)
        {
            List<(string, string, string)> result = new List<(string, string, string)>();

            // Squaring distances for the computation of pythagorean theorem
            foreach (string key in distances.Keys)
            {
                distances[key] = (float)Math.Pow(distances[key], 2);
            }


            // Matching Pythagorean theorem for each triplet of points
            List<string> keys = distances.Keys.ToList();
            
            for(int i=0; i < keys.Count -2; i++)
            {
                for (int j = i + 1; j < keys.Count - 1; j++)
                {
                    for (int k = j + 1; k < keys.Count; k++)
                    {
                        float a = distances[keys[i]];
                        float b = distances[keys[j]];
                        float c = distances[keys[k]];

                        // Sort the triplet so that c is always the largest
                        float[] sorted = { a, b, c };
                        Array.Sort(sorted);
                        a = sorted[0];
                        b = sorted[1];
                        c = sorted[2];

                        if (Math.Abs(a  + b  - c ) <=1e-6)
                        {
                            result.Add((keys[i], keys[j], keys[k]));
                        }
                    }
                }
            }

            return result;
        }
    }
}