using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bejegyzesek
{
    internal class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejott;
        private DateTime szerkesztve;

        public Bejegyzes(string szerzo, string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            this.letrejott = DateTime.Now;
            this.szerkesztve = DateTime.Now;
        }

        public string Szerzo { get => szerzo; }
        public string Tartalom { get => tartalom; set {
                tartalom = value;
                Szerkesztve = DateTime.Now;
            } }
        public int Likeok { get => likeok; set => likeok = value; }
        public DateTime Letrejott { get => letrejott; }
        public DateTime Szerkesztve { get => szerkesztve; set => szerkesztve = value; }

        public int Like()
        {
            return Likeok++;
        }
        public override string ToString()
        {
            if (letrejott != szerkesztve)
            {
                return $"{szerzo} - {likeok} - {letrejott}\nSzerkesztve: {szerkesztve}\n{tartalom}";
            }
            else
            {
                return $"{szerzo} - {likeok} - {letrejott}\n{tartalom}";
            }
            
        }
    }
}
