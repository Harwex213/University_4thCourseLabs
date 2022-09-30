using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab05
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Simplex : ISimplex
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public string Concat(string s, double d)
        {
            return s + " " + d.ToString();
        }

        public A Sum(A msu1, A msu2)
        {
            return new A(msu1.S + msu2.S, msu1.K + msu2.K, msu1.F + msu2.F);
        }
    }
}
