
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;

namespace StringSearch
{
    class Program
    {
        public static void Main()
        {
            string text1 = File.ReadAllText("C:\\Users\\Maks\\Desktop\\uni_sem4\\os\\lab4\\StringSearch\\StringSearch\\text1.txt");
            string text2 = File.ReadAllText("C:\\Users\\Maks\\Desktop\\uni_sem4\\os\\lab4\\StringSearch\\StringSearch\\text2.txt");
            string text3 = File.ReadAllText("C:\\Users\\Maks\\Desktop\\uni_sem4\\os\\lab4\\StringSearch\\StringSearch\\text3.txt");
            string pattern11 = "Why does my action strike them as so horrible";
            string pattern12 = "Why does my action strike them as so horrible?” he said to himself. “Is it because it was a crime? What is meant by crime? My conscience is at rest";
            string pattern13 = "Why does my action strike them as so horrible?” he said to himself. “Is it because it was a crime? What is meant by crime? My conscience is at rest. Of course, it was a legal crime, of course, the letter of the law was broken and blood was shed. Well, punish me for the letter of the law";

            string pattern21 = "In the first case it was necessary to renounce the";
            string pattern22 = "In the first case it was necessary to renounce the consciousness of an unreal immobility in space and to recognize a motion";
            string pattern23 = "In the first case it was necessary to renounce the consciousness of an unreal immobility in space and to recognize a motion we did not feel; in the present case it is similarly necessary to renounce a freedom that does not exist, and to recognize a dependence of which we are not conscious.";

            string pattern31 = "bleglmlsyihcevjzeswhiaurlobikfnzrceftxeynblrowyswe";
            string pattern32 = "bleglmlsyihcevjzeswhiaurlobikfnzrceftxeynblrowyswegfflglzibvgeagsfssdhpljrgrkuuhjwzfzwdxqwurbpekyzmwzyaglxasrhczooyseshwolkkjuvnhbnqwvmriyx";
            string pattern33 = "bleglmlsyihcevjzeswhiaurlobikfnzrceftxeynblrowyswegfflglzibvgeagsfssdhpljrgrkuuhjwzfzwdxqwurbpekyzmwzyaglxasrhczooyseshwolkkjuvnhbnqwvmriyxktqxboxgbgdschfuwjqgloaiptfrdyasnqurmauijguqgxogygrxetmrgsihrjnrlgshkvkernuefyqfdxotlymmgfakwpjxgeinlnzrzfppbuyxrqeoqllrwnjsgvizqnawkiyodeuayjduuhhbxcpgrdvegqeoxoatbwzpqiwvxzmykfprluaktlgzihuebfacsffamqzansdandmflvvakwbolqgsmmfknddyvlmumuqhdzrviknqyrgmrflvushoetmvypewssdxtmsyazslgukegkuirlrpchevkzyygzoafmqhovzdtndlkkhlbelecvtoimkct";

            TimeAnalyzeRabinKarpSearch(text1, pattern11);
            TimeAnalyzeRabinKarpSearch(text1, pattern12);
            TimeAnalyzeRabinKarpSearch(text1, pattern13);
            Console.WriteLine("\n");
            TimeAnalyzeRabinKarpSearch(text2, pattern21);
            TimeAnalyzeRabinKarpSearch(text2, pattern22);
            TimeAnalyzeRabinKarpSearch(text2, pattern23);
            Console.WriteLine("\n");
            TimeAnalyzeRabinKarpSearch(text3, pattern31);
            TimeAnalyzeRabinKarpSearch(text3, pattern32);
            TimeAnalyzeRabinKarpSearch(text3, pattern33);

            Console.WriteLine("\n");
            Console.WriteLine("\n");

            TimeAnalyzeIndexOf(text1, pattern11);
            TimeAnalyzeIndexOf(text1, pattern12);
            TimeAnalyzeIndexOf(text1, pattern13);
            Console.WriteLine("\n");
            TimeAnalyzeIndexOf(text2, pattern21);
            TimeAnalyzeIndexOf(text2, pattern22);
            TimeAnalyzeIndexOf(text2, pattern23);
            Console.WriteLine("\n");
            TimeAnalyzeIndexOf(text3, pattern31);
            TimeAnalyzeIndexOf(text3, pattern32);
            TimeAnalyzeIndexOf(text3, pattern33);
        }

        static void TimeAnalyzeRabinKarpSearch(string text, string pattern)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int pos = RabinKarpSearch(text, pattern);
            stopwatch.Stop();
            Console.WriteLine($"Sequence size: {text.Length}, Patternt size: {pattern.Length} Elapsed time: {stopwatch.ElapsedMilliseconds} ms | pos = {pos}");
        }

        static void TimeAnalyzeIndexOf(string text, string pattern)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int pos = text.IndexOf(pattern);
            stopwatch.Stop();
            Console.WriteLine($"Sequence size: {text.Length}, Patternt size: {pattern.Length} Elapsed time: {stopwatch.ElapsedMilliseconds} ms | pos = {pos}");
        }

        static int HashString(string str)
        {
            int hash = 0;
            foreach (char c in str)
            {
                hash = hash * 256 + c;
            }
            return hash;
        }


        static int RabinKarpSearch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            int patternHash = HashString(pattern);
            int textHash = HashString(text.Substring(0, m));

            for (int i = 0; i <= n - m; i++)
            {
                if (patternHash == textHash && text.Substring(i, m) == pattern)
                    return i;

                if (i < n - m)
                {
                    textHash = textHash - text[i] * (int)Math.Pow(256, m - 1);
                    textHash = textHash * 256 + text[i + m];
                }
            }

            return -1;
        }
    }
}