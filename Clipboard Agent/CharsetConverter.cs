namespace ClipboardAgent
{
    public class CharsetConverter
    {
        private readonly List<Charset> _charsets;
        private readonly List<Charset> _charsetSignatures;

        public CharsetConverter()
        {
            _charsets = CreateCharsets();

            _charsetSignatures = _charsets.Select(x => new Charset
            {
                Name = x.Name,
                LowerCaseCharset = string.Concat(x.LowerCaseCharset.Where(y => !_charsets.Any(z => z.Name != x.Name && z.LowerCaseCharset.Contains(y)))),
                UpperCaseCharset = string.Concat(x.UpperCaseCharset.Where(y => !_charsets.Any(z => z.Name != x.Name && z.UpperCaseCharset.Contains(y))))
            }).ToList();
        }

        public string Convert(string text, string sourceCharsetName, string targetCharsetName)
        {
            var from = _charsets.First(x => x.Name == sourceCharsetName);
            var to = _charsets.First(x => x.Name == targetCharsetName);

            var result = "";
            foreach (var ch in text)
            {
                var index = from.All.IndexOf(ch);
                var newChar = index >= 0 ? to.All[index] : ch;
                result += newChar;
            }

            return string.Concat(result);
        }

        public bool TryDetectCharsetName(string text, out string chrasetName)
        {
            chrasetName = _charsetSignatures.Any(x => text.Any(y => x.All.Contains(y))) ? _charsetSignatures.First(x => text.Any(y => x.All.Contains(y))).Name : "";
            return !string.IsNullOrEmpty(chrasetName);
        }

        public bool ContainsCharset(string charset) =>
            _charsets.Any(x => x.Name == charset);

        private List<Charset> CreateCharsets()
        {
            return new List<Charset>() {
                new Charset
                {
                Name = "en",
                LowerCaseCharset = "`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./",
                UpperCaseCharset = "~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?"
                },
                new Charset
                {
                    Name = "ru",
                    LowerCaseCharset = "ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю.",
                    UpperCaseCharset = "Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,"
                },
                new Charset
                {
                    Name = "ro",
                    LowerCaseCharset = "„1234567890-=qwertyuiopăîâasdfghjklșțzxcvbnm,./",
                    UpperCaseCharset = "”!@#$%^&*()_+QWERTYUIOPĂÎÂASDFGHJKLȘȚZXCVBNM;:?"
                }
            };
        }
    }
}