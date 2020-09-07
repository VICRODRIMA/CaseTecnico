using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Application
{
    public class Response
    {
        private readonly IList<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }
        public dynamic Result { get; }

        public Response() => Errors = new System.Collections.ObjectModel.ReadOnlyCollection<string>(_messages);

        public Response(object result) : this() => Result = result;

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
        public bool HasMessages => _messages.Any();
    }
}