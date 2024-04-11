namespace ClipboardAgent
{
    public class Charset
    {
        public string Name { get; set; }
        public string LowerCaseCharset { get; set; }
        public string UpperCaseCharset { get; set; }
        public string All
        {
            get
            {
                if (string.IsNullOrEmpty(_all))
                    _all = LowerCaseCharset + UpperCaseCharset;

                return _all;
            }
        }

        private string _all;
    }
}