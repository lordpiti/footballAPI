
using System;
using System.Data.Common;


namespace Util.Exceptions {
    
    public class SQLException : DbException {
    
        public SQLException(string msg)
            : base(msg) { }

    
    }

}
