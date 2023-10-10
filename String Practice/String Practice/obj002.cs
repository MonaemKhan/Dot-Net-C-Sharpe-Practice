using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Practice;

public class obj002 : wow
{
    internal int x = 10;
    protected int y = 20;
    public override string Description()
    {
        throw new NotImplementedException();
    }

    public override string Name()
    {
        throw new NotImplementedException();
    }
}

public class obj003
{
    public void show()
    {
        obj002 o1 = new obj002();
        Console.WriteLine(o1.x);
    }
}
