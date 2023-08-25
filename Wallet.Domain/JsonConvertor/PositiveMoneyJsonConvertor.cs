using System.Text.Json;
using System.Text.Json.Serialization;
using Wallet.Domain.Common;

namespace Wallet.Domain.JsonConvertor;

public class PositiveMoneyJsonConvertor : JsonConverter<PositiveMoney>
{
    public override PositiveMoney Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
            throw new JsonException();

        var amount = reader.GetDecimal();

        if (amount < 0)
            throw new JsonException("Value must be positive");

        return new PositiveMoney(amount);
    }

    public override void Write(Utf8JsonWriter writer, PositiveMoney value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.ToDecimal);
    }
}