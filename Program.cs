namespace laba5
/*Створити суперклас Геометрична фігура і підкласи Квадрат, Коло, Відрізок, Чотирикутник, Ромб, Паралелограм. 
 *Подумати, які з вищенаведених підкласів також можуть бути суперкласами. За допомогою конструктора задати колір фігури. 
 *Визначити довжину відрізків, з яких складається квадрат.*/
{
    class Program
    {
        static void Main(string[] args)
        {
            Segment seg = new Segment('-',"red");
            Console.WriteLine("Segment color : " + seg.Color + "\n");
           
            Tetragon tet = new Tetragon('-', "white", 2,2,3,9);
            Console.WriteLine("Tetragon color : " + tet.Color + "\nTetragon left side {0}\nTetragon top side {1}\nTetragon right side {2}\nTetragon bottom side {0} ", tet.LeftSide, tet.TopSide, tet.RightSide, tet.BottomSide + "\n");
           
            Parallelogram par = new Parallelogram('-',"green", 4, 8);
            Console.WriteLine("\nParallelogram color : " + par.Color + "\nParallelogram left side {0}\nParallelogram top side {1}\nParallelogram right side {0}\nParallelogram bottom side {1} ", par.LeftSide, par.TopSide );
           
            Diamond dia = new Diamond('-',"yellow",6);
            Console.WriteLine("\nDiamond color : " + dia.Color + "\nDiamond left side {0}\nDiamond top side {0}\nDiamond right side {0}\nDiamond bottom side {0}", dia.TopSide);
      
            Quadrate qua = new Quadrate('-', "black", 11);
            Console.WriteLine("\nQuadrate color : " + qua.Color + "\nQuadrate left side {0}\nQuadrate top side {0}\nQuadrate right side {0}\nQuadrate bottom side {0}", qua.TopSide);

            Rectangle rec = new Rectangle('-',"orange",2, 13);
            Console.WriteLine("\nRectangle color : " + rec.Color + "\nRectangle left side {0}\nRectangle top side {1}\nRectangle right side {0}\nRectangle bottom side {1} ", rec.LeftSide, rec.TopSide);

            Circle cir = new Circle('-' , " violet" ,6);
            Console.WriteLine("\nCircle color : " + cir.Color + "\nCircle radius : " + cir.Radius);

            Console.ReadKey();
        }
    }
    public class GeometricFigure
    {
        public char Point = '-';
        public string Color { get; set; }

        public GeometricFigure(char point, string color)
        {
            Point = point;
            Color = color;
        }
    }
    public class Segment : GeometricFigure
    {
        public Segment(char point, string color) : base(point, color)
        {

        }
        public string CreateSegment(int num)
        {
            string count = "";
            for (int i = 0; i < num; i++)
            {
                count += Point.ToString();
            }
            return count;
        }
    }
    public class Tetragon : Segment
    {
        public string LeftSide { get; set; }
        public string TopSide { get; set; }
        public string RightSide { get; set; }
        public string BottomSide { get; set; }

        public Tetragon(char point, string color, int leftSide, int topSide, int rightSide = 0, int bottomSide = 0)
            : base(point, color)
        {
            LeftSide = CreateSegment(leftSide);
            TopSide = CreateSegment(topSide);
            RightSide = CreateSegment(rightSide == 0 ? leftSide : rightSide);
            BottomSide = CreateSegment(bottomSide == 0 ? topSide : bottomSide);
        }
    }
    public class Parallelogram : Tetragon
    {
        public string Parallelism { get; set; }

        public Parallelogram(char point, string color, int leftSide, int topSide, int rightSide = 0, int bottomSide = 0)
            : base(point, color, leftSide, topSide, rightSide, bottomSide)
        {
            Parallelism = $"{TopSide}{BottomSide} and {LeftSide}{RightSide}";
        }
    }

    public class Diamond : Parallelogram
    {
        public Diamond(char point, string color, int leftSide)
            : base(point, color, leftSide, leftSide)
        {
            RightSide = LeftSide;
            BottomSide = LeftSide;
            TopSide = LeftSide;
        }

    }

    public class Quadrate : Diamond
    {
        public string Perepedicularity { get; set; }

        public Quadrate(char point, string color, int leftSide)
            : base(point, color, leftSide)
        {
            Perepedicularity = $"{LeftSide}_|_{TopSide} and {RightSide}_|_{BottomSide}";
        }

        public int FindLen()
        {
            return LeftSide.Length;
        }
    }

    class Rectangle : Parallelogram
    {
        private char v1;
        private string v2;
        private int v3;
        private int v4;

        public string Perepedicularity { get; set; }

        public Rectangle(char point, string color, int leftSide, int topSide, int rightSide = 0, int bottomSide = 0)
            : base(point, color, leftSide, topSide, rightSide, bottomSide)
        {
            Perepedicularity = $"{LeftSide}_|_{TopSide} and {RightSide}_|_{BottomSide}";
        }
    }

    public class Circle : GeometricFigure
    {
        public double Radius { get; set; }
        public double Len { get; set; }

        public Circle(char point, string color, double radius) : base(point, color)
        {
            Radius = radius;
            CreateCircle();
        }

        public void CreateCircle()
        {
            Len = 2 * Math.PI * Radius;
        }
    }
}
