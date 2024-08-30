using Program;



namespace lab_3
{
    internal class Point
    {
        public float cal_distance(Point2D a_point, Point2D b_point)
        {
            float cal_x = (float)Math.Pow((a_point.x - b_point.x),2);
            float cal_y = (float)Math.Pow((a_point.y - b_point.y), 2);
            return (float)Math.Sqrt(cal_x + cal_y);

        }
    }
}
