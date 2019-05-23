using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Class
{
    public class FlashMessage
    {
        public string Message { get; private set; }

        public TypeMessage Type { get; private set; }

        public FlashMessage(string message, TypeMessage type)
        {
            this.Message = message;
            this.Type = type;
        }
    }

    public enum TypeMessage
    {
        SUCCESS,
        WARNING,
        DANGER
    }
}
