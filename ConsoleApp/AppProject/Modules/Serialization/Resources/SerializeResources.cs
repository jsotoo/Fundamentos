using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Modules
{
    public class ClassToSerialize1
    {
        public int Age = 100;
        public string Name = "Whololo";
    }

    [Serializable]
    public class ClassToSerialize2
    {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
    }

    [Serializable]
    public class ClassToSerialize3
    {
        public string V1 {
            get {
                return _v1;
            }
        }

        public int V2
        {
            get
            {
                return _v2;
            }
        }
        private string _v1;
        private int _v2;

        public ClassToSerialize3()
        {
        }

        public ClassToSerialize3(string v1, int v2)
        {
            _v1 = v1;
            _v2 = v2;
        }
    }
}
