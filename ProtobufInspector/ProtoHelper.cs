using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtobufInspector
{
    class ProtoHelper
    {
        public static Object Deserialize(Type t, byte[] data, out string error)
        {
            error = string.Empty;
            if (data == null) return null;
            try
            {
                using (var stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize(t, stream);
                }
            }
            catch(Exception e)
            {
                error = e.Message;
            }
            return null;
        }
    }
}
