using System.Collections.Generic;

namespace Client.DTO
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