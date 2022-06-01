using System;
namespace Domain.Entities
{
	public class Entity
	{
        public Guid Id { get; set; }

        public DateTime CreatedAt { get;  set; }
        public DateTime UpdatedAt { get;  set; }
        public DateTime DeletedAt { get;  set; }

        public bool Excluded { get; set; }

        public Entity()
		{
			Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
		}

        public void Delete()
        {
            Excluded = true;
            DeletedAt = DateTime.UtcNow; ;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow; ;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}

