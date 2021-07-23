using System.Collections.Generic;

namespace Server.Models
{
    public class ResponseCollection<T>
    {
        public IEnumerable<T> Items { get; set; }
        public ResponseCollection(IEnumerable<T> items)
        {
            Items = items;
        }
    }
}