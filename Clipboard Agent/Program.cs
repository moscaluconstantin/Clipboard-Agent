using TextCopy;

namespace ClipboardAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = ClipboardService.GetText();

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Clipboard is empty.");
                return;
            }

            var converter = new CharsetConverter();

            if (args == null || args.Length == 0)
            {
                converter.TryDetectCharsetName(text, out var charset);

                var result = charset != "en" ? converter.Convert(text, charset, "en") : converter.Convert(text, "en", "ru");

                return;
            }

            if (args.Length == 1)
            {
                converter.TryDetectCharsetName(text, out var charset);

                var result = converter.Convert(text, charset != "en" ? charset : "en", args[0]);
                ClipboardService.SetText(result);

                Console.WriteLine("Your clipboard was updated.");
                return;
            }



            Console.WriteLine($"Convert from {args[0]} to {args[1]}");
        }

        private static void TryReplace(string text, string from, string to, CharsetConverter converter)
        {
            if (!converter.ContainsCharset(from))
            {
                Console.WriteLine($"Unknown charset '{from}'.");
                return;
            }

            if (!converter.ContainsCharset(to))
            {
                Console.WriteLine($"Unknown charset '{to}'.");
                return;
            }

            var result = converter.Convert(text, from, to);
            ClipboardService.SetText(result);

            Console.WriteLine("Your clipboard was updated.");
        }
    }
}