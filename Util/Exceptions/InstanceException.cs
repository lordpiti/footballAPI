using System;

namespace Util.Exceptions {

    public class InstanceException : ModelException {

        private Object key;
        private String className;

        protected InstanceException(String specificMessage, Object key,
            String className)
            : base(specificMessage + " (key = '" + key +
                                    "' - className = '" + className + "')") {

            this.key = key;
            this.className = className;

        }

        #region Properties

        public Object Key {
            get { return key; }
        }


        public String ClassName {
            get { return className; }
        }

        #endregion

    }
}
