using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;
using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;

namespace Futbol.ActionProcessor
{
    public interface NonTransactionalPlainAction
    {
         Object execute(DbConnection connection);

    }
}
