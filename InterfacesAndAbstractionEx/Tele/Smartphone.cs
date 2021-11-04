
using System.Linq;
using System.Text;

namespace Tele
{
    public class Smartphone : ICallable, IBrowseable
    {
        private string model;

        public Smartphone(string model)
        {
            this.model = model;
        }

        public string Browse(string website)
        {

            bool hasDigit = website.Any(char.IsDigit);
            if (hasDigit)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid URL!");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Browsing: {website}!");
                return sb.ToString();
            }
        }

        public string Call(string phone)
        {
            bool hasCharacter = phone.Any(char.IsLetter);
            if (hasCharacter)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid number!");
                return sb.ToString();
            }
            else if(phone.Length == 10)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Calling... {phone}");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Dialing... {phone}");
                return sb.ToString();
            }
        }
    }
}