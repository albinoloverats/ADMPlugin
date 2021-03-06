﻿using System.IO;
using Newtonsoft.Json;

namespace ADMPlugin
{
    public class InternalJsonSerializer
    {
        private readonly JsonSerializer _jsonSerializer;

        public InternalJsonSerializer() : this(new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All,
            ContractResolver = new AdaptContractResolver(),
            SerializationBinder = new InternalSerializationBinder()
        })
        {
        }

        public InternalJsonSerializer(JsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public void Serialize<T>(T dataModel, string file)
        {
            using (var fileStream = File.Open(file, FileMode.Create, FileAccess.ReadWrite))
            using (var streamWriter = new StreamWriter(fileStream))
            using (var textWriter = new JsonTextWriter(streamWriter) {Formatting = Formatting.Indented})
            {
                _jsonSerializer.Serialize(textWriter, dataModel);
            }
        }

        public T Deserialize<T>(string file)
        {
            using (var fileStream = File.Open(file, FileMode.Open))
            using (var streamReader = new StreamReader(fileStream))
            using (var textReader = new InternalJsonTextReader(streamReader))
            {
                return _jsonSerializer.Deserialize<T>(textReader);
            }
        }
    }
}
