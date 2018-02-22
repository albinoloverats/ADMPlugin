using System;
using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using ProtoBuf;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin
{
    public interface IProtobufSerializer
    {
        void Write<T>(string path, T content);
        void WriteSpatialRecords(string path, IEnumerable<SpatialRecord> spatialRecords);
        T Read<T>(string path);
        IEnumerable<SpatialRecord> ReadSpatialRecords(string path);
    }

    public class ProtobufSerializer : IProtobufSerializer
    {
        public ProtobufSerializer()
        {            

        }

        public void Write<T>(string path, T content)
        {
            var type = content.GetType();
            if (!type.Namespace.StartsWith("System") && !type.Namespace.StartsWith("AgGateway.ADAPT.ApplicationDataModel"))
            {
                var baseType = type.BaseType;
                Write(path, Convert.ChangeType(content, baseType));
            }
            else
            {
            Write<T>(path, content, DataModel.Instance.Model);
        }
        }

        private void Write<T>(string path, T content, RuntimeTypeModel model)
        {
            using (var fileStream = File.Open(path, FileMode.Create))
            {
                model.Serialize(fileStream, content);
            }
        }

        public T Read<T>(string path)
        {
            return Read<T>(path, DataModel.Instance.Model);
        }

        private T Read<T>(string path, RuntimeTypeModel model)
        {
            using (var fileStream = File.OpenRead(path))
            {
                return (T)model.Deserialize(fileStream, null, typeof(T));
            }
        }

        public void WriteSpatialRecords(string path, IEnumerable<SpatialRecord> spatialRecords)
        {
            using (var fileStream = File.Open(path, FileMode.Create))
            {
                foreach (var spatialRecord in spatialRecords)
                {
                    DataModel.Instance.Model.SerializeWithLengthPrefix(fileStream, spatialRecord, typeof(SpatialRecord), PrefixStyle.Base128, 1);
                }
            }
        }

        public IEnumerable<SpatialRecord> ReadSpatialRecords(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                while (!IsEndOfStream(fileStream))
                {
                    var spatialRecord = new SpatialRecord();
                    DataModel.Instance.Model.DeserializeWithLengthPrefix(fileStream, spatialRecord, typeof(SpatialRecord), PrefixStyle.Base128, 1);
                    yield return spatialRecord;
                }
            }
        }

        private bool IsEndOfStream(FileStream fileStream)
        {
            return fileStream.Position + 20 > fileStream.Length;
        }
    }

}
