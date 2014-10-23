using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomException
{
    [Serializable]
    class CarIsDeadException1 : ApplicationException
    {
        //private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException1()
        {

        }

        public CarIsDeadException1(string message, string cause, DateTime time)
            :base(message)
        {
            //messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        


        /*
        public override string Message
        {
            get
            {
                return string.Format("Car Error Message: {0}", messageDetails);
            }
        }
        */

    }

    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
         public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException() { }
        public CarIsDeadException(string message) : base(message) { }
        public CarIsDeadException(string message, Exception inner) : base(message, inner) { }
        protected CarIsDeadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }


         public CarIsDeadException(string message, string cause, DateTime time)
            :base(message)
        {
            //messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
