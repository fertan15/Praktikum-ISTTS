using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriW3
{
    public class RingkasanPenjualan
    {
        public string Item { get; set; }
        public int Terjual { get; set; }
        public int Pendapatan { get; set; }

        public override string ToString()
        {
            return $"- {Item}: {Terjual} unit terjual, pendapatan {Pendapatan} G.";
        }
    }
}
