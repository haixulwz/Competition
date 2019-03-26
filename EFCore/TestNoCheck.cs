using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore
{
    public class TestNoCheck
    {
        public static void NoCheck(DbQueryCommit rw1,DbQueryCommit rw2,DbQueryCommit rw3) {
            int id = 1;
            Blog blog1 = rw1.Query<Blog>(id);
            Blog blog2 = rw2.Query<Blog>(id);
            rw1.Commit(()=>blog1.Url=nameof(rw1));
            rw2.Commit(() => blog2.Url = nameof(rw2));

            Blog blog3 = rw3.Query<Blog>(id);

        }
    }
}
