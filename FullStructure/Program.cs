namespace FullStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Cha mẹ \"thói đời\" ăn ở bạc");
            Console.WriteLine("Các đối số đầu vào: ");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            Console.ReadLine();
        }
    }
}