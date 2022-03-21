using System;

namespace TestTask
{
    class Test
    {
        public String Q;
        public String V1;
        public String V2;
        public String V3; public int PV;

        public Test()
        {
            Q = "";
            V1 = "";
            V2 = "";
            V3 = "";
            PV = 0;
        }

        public Test(string q, string v1, string v2, string v3, int pv)
        {
            Q = q;
            V1 = v1;
            V2 = v2;
            V3 = v3;
            PV = pv;
        }
    }
}