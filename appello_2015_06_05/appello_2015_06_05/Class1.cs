namespace appello_2015_06_05
{
    public static class Class1
    {
        public interface IMyString 
        {
            public string myString { get; set; }
        }

        public static void Main(String[] args)
        {
            var str = new List<string>()
            {
                "stringa",
                "di",
                "prova",
                "per",
                "test"
            };
            foreach (var item in str.CodingToMorse())
            {
                Console.Write(item);
                Console.WriteLine();
            }
        }

        public static IEnumerable<string> CodingToMorse(this IEnumerable<string> message)
        {
            if (message == null)
                throw new ArgumentNullException();
            
            foreach (var item in message)
            {
                var test = "";
                foreach (var elem in item)
                {
                    var res = elem.ToMorse();
                    if (res == "")
                        throw new ArgumentException();
                    test += res;
                    test += " ";
                }
                yield return test;
            }
        }

        public static string ToMorse(this char inChar)
        {
            if (inChar == null)
                throw new ArgumentNullException();
            switch (inChar)
            {
                case 'a':
                {
                    return ".-";
                }
                case 'b':
                {
                    return "-...";
                }
                case 'c':
                {
                    return "-.-.";
                }
                case 'd':
                {
                    return "-..";
                }
                case 'e':
                {
                    return ".";
                }
                case 'f':
                {
                    return "..-.";
                }
                case 'g':
                {
                    return "--.";
                }
                case 'h':
                {
                    return "....";
                }
                case 'i':
                {
                    return "..";
                }
                case 'j':
                {
                    return ".---";
                }
                case 'k':
                {
                    return "-.-";
                }
                case 'l':
                {
                    return ".-..";
                }
                case 'm':
                {
                    return "--";
                }
                case 'n':
                {
                    return "-.";
                }
                case 'o':
                {
                    return "---";
                }
                case 'p':
                {
                    return ".--.";
                }
                case 'q':
                {
                    return "--.-";
                }
                case 'r':
                {
                    return ".-.";
                }
                case 's':
                {
                    return "...";
                }
                case 't':
                {
                    return "-";
                }
                case 'u':
                {
                    return "..-";
                }
                case 'v':
                {
                    return "...-";
                }
                case 'w':
                {
                    return ".--";
                }
                case 'x':
                {
                    return "-..-";
                }
                case 'y':
                {
                    return "-.--";
                }
                case 'z':
                {
                    return "--..";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}