using System;

namespace Core.Models.Partner
{
    public class Partner : IEntity
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public DateTime Created { get; set; }

        public Contact? Contact { get; set; }

        public string? Website { get; set; }

        public Support? Support { get; set; }
    }
}
