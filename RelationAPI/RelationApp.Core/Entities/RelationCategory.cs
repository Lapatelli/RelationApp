using System;

namespace RelationApp.Core.Entities
{
    public partial class RelationCategory
    {
        public Guid? RelationId { get; set; }
        public Guid? CategoryId { get; set; }
        public Relation Relation { get; set; }
        public Category Category { get; set; }
    }
}
