using System.ComponentModel.DataAnnotations;

namespace Wallet.Domain.Common
{
    public interface IBaseEntity
    {
    }

    public interface IBaseEntity<out TKey> : IBaseEntity
    {
        public TKey? Id { get; }
    }

    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public virtual TKey? Id { get; set; }
        [Timestamp]
        public byte[]? RowVersion { get; set; } = null;

        //public DateTimeOffset CreatedDateTime => DateTimeOffset.UtcNow;
        //public DateTimeOffset? UpdatedDateTime { get; set; }

        private int? _requestedHashCode = 0;

        public bool IsTransient()
        {
            return Id != null && Id.Equals(default(TKey));
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity<TKey> key)
                return false;

            if (ReferenceEquals(this, key))
                return true;

            if (GetType() != key.GetType())
                return false;

            if (key.IsTransient() || IsTransient())
                return false;

            return key == this;
        }
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                _requestedHashCode ??= Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(BaseEntity<TKey> left, BaseEntity<TKey> right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        public static bool operator !=(BaseEntity<TKey> left, BaseEntity<TKey> right)
        {
            return !(left == right);
        }
    }
    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }
}