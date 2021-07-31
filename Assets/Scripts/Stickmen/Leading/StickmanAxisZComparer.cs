using System.Collections.Generic;

public class StickmanAxisZComparer : IComparer<Stickman>
{
    public int Compare(Stickman x, Stickman y)
    {
        float z1 = x.transform.position.z, z2 = y.transform.position.z;

        if (z1 > z2)
        {
            return -1;
        }
         
        if(z1 == z2)
        {
            return 0;
        }

        if (z1 < z2)
        {
            return 1;
        }

        return -1;
    }
}