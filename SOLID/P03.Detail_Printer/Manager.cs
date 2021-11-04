using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee, IPrintable
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public new string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            foreach (var document in Documents)
            {
                sb.AppendLine(document);
            }

            return sb.ToString().Trim();
        }
    }
}
