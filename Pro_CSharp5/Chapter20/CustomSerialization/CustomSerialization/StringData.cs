using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CustomSerialization {
    [Serializable]
    class StringData : ISerializable {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";

        public StringData() {

        }

        public StringData(SerializationInfo si, StreamingContext ctx) {
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("First_Item", dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }
    }

    [Serializable]
    class MoreData {
        public string dataItemOne = "First data block";
        private string dataItemTwo = "More data";

        [OnSerializing]
        private void OnSerializing(StreamingContext ctx) {
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext ctx) {
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }

      
    }
}
