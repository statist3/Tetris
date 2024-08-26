using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Polimor
{
    abstract class Humans
    {
        protected int age;
        protected int height;

        public void Set(int a)
        {
            age = a;
        }

        public void Set(int a, int h)
        {
            age = a;
            height = h;
        }

        public abstract void Write();
    }
}
