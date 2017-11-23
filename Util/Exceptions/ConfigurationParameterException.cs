using System;
using System.Text;

namespace Util.Exceptions {
    
    public class ConfigurationParameterException : InternalErrorException {

        public ConfigurationParameterException(Exception e) : base(e) { }

        public ConfigurationParameterException(String parameter) 
            :base ("Configuration Parameter '" + parameter + "' not found") { }
             
    }
}

