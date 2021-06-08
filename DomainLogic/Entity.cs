namespace DomainLogic
{
    public abstract class Entity
    {
        public int Id { get; }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(obj);
        }

        public bool Equals(Entity other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity x, Entity y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Entity x, Entity y)
        {
            return !(x == y);
        }
    }


}
