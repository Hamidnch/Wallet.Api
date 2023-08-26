using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wallet.Domain.Common;

namespace Wallet.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SetDecimalPrecision(this ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            foreach (var property in builder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal)
                                     || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18, 6)");
            }
        }

        public static void AddDecimalConverter(this ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var decimalConvertor = new ValueConverter<PositiveMoney, decimal>(
                positiveMoney => positiveMoney.ToDecimal,
                value => new PositiveMoney(value));

            var nullableDecimalConvertor =
                new ValueConverter<PositiveMoney?, decimal>(
                    positiveMoney => positiveMoney!.Value.ToDecimal,
                    value => new PositiveMoney(value));


            var entityTypes = builder.Model.GetEntityTypes();
            foreach (var property in entityTypes
                         .SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(PositiveMoney))
                    property.SetValueConverter(decimalConvertor);

                if (property.ClrType == typeof(PositiveMoney?))
                    property.SetValueConverter(nullableDecimalConvertor);
            }
        }

        public static void AddDateTimeOffsetConverter(this ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            var dateTimeOffsetConverter = new ValueConverter<DateTimeOffset, DateTime>(
                dateTimeOffset => dateTimeOffset.UtcDateTime,
                dateTime => new DateTimeOffset(dateTime));

            var nullableDateTimeOffsetConverter =
                new ValueConverter<DateTimeOffset?, DateTime>(
                    dateTimeOffset => dateTimeOffset!.Value.UtcDateTime,
                    dateTime => new DateTimeOffset(dateTime));

            // SQLite does not support DateTimeOffset

            var entityTypes = builder.Model.GetEntityTypes();
            foreach (var property in entityTypes.SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(DateTimeOffset))
                    property.SetValueConverter(dateTimeOffsetConverter);

                if (property.ClrType == typeof(DateTimeOffset?))
                    property.SetValueConverter(nullableDateTimeOffsetConverter);
            }
        }

        public static void AddDateTimeUtcKindConverter(this ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            // If you store a DateTime object to the DB with a DateTimeKind of either `Utc` or `Local`,
            // when you read that record back from the DB you'll get a DateTime object whose kind is `Unspecified`.
            // Here is a fix for it!

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => !v.HasValue ? v : ToUniversalTime(v),
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

            var entityTypes = builder.Model.GetEntityTypes();
            foreach (var property in entityTypes.SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(DateTime))
                    property.SetValueConverter(dateTimeConverter);

                if (property.ClrType == typeof(DateTime?))
                    property.SetValueConverter(nullableDateTimeConverter);
            }
        }

        private static DateTime? ToUniversalTime(DateTime? dateTime)
        {
            if (!dateTime.HasValue) return null;

            return dateTime.Value.Kind == DateTimeKind.Utc ? dateTime : dateTime.Value.ToUniversalTime();
        }

    }
}
