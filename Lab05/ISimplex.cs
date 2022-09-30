using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab05
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface ISimplex
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        string Concat(string x, double y);

        [OperationContract]
        A Sum(A x, A y);
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "Lab05.ContractType".
    [DataContract]
    public class A
    {
        private string s;
        private int k;
        private float f;

        public A() { }
        public A(string s, int k, float f)
        {
            S = s;
            K = k;
            F = f;
        }

        [DataMember]
        public string S { get => s; set => s = value; }

        [DataMember]
        public int K { get => k; set => k = value; }

        [DataMember]
        public float F { get => f; set => f = value; }
    }
}
