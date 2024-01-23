namespace appello_2019_07_09
{
    public static class Class1
    {
        public static void Main()
        {
            string word = "CAne";
            foreach (var elem in word.MexicanWave().Take(10).ToList())
            {
                Console.WriteLine(elem);
            }
        }

        public static IEnumerable<string> MexicanWave(this string word)
        {
            if (word == null)
                throw new ArgumentNullException();
            if (word.Length < 2)
                throw new ArgumentException();
            while (true)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    string res = "";
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (!char.IsLetter(word[i]))
                            throw new ArgumentException();
                        if (j == i)
                            res += char.ToUpper(word[i]);
                        else res += char.ToLower(word[i]);
                    }
                    yield return res;
                }
            }
        }
    }
}