using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Facade
{
    public static class LoggingEvents
    {
        public const int GET_ITEM = 1001;
        public const int GET_ITEMS = 1002;
        public const int CREATE_ITEM = 1003;
        public const int UPDATE_ITEM = 1004;
        public const int DELETE_ITEM = 1005;
        public const int DATABASE_ERROR = 2000;
        public const int SERVICE_ERROR = 2001;
        public const int ERROR = 2002;
        public const int ACCESS_METHOD = 3000;
    }
}
