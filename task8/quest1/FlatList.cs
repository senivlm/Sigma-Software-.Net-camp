using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task8
{
    class FlatList : List<Flat>
    {

        public static FlatList operator +(FlatList a, FlatList b)
        {
            FlatList res = new FlatList();
                res.AddRange(a);
                res.AddRange(b);
            return res;
        }
        public static FlatList operator -(FlatList a, FlatList b)
        {
            // a.Excapt(b) та if (!b.Contains(first)) не працюють

            FlatList res = new FlatList();
            res.AddRange(a);
            //краще було через множини. Так лишні вітки циклу
            foreach (var first in a)
                foreach (var second in b)
                    if (first == second)
                        res.Remove(first);
            return res;
        }
       
    }
    
}
