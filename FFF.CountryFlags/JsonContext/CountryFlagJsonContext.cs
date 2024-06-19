using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FFF.CountryFlags
{
    [JsonSerializable(typeof(CountryFlag))]
    [JsonSerializable(typeof(AttachFlag))]
    [JsonSerializable(typeof(Currency))]
    [JsonSerializable(typeof(FlagSource))]
    [JsonSerializable(typeof(Language))]
    [JsonSerializable(typeof(RegionalBloc))]
    [JsonSerializable(typeof(Translation))]
    [JsonSerializable(typeof(IEnumerable<CountryFlag>))]
    [JsonSerializable(typeof(IEnumerable<AttachFlag>))]
    [JsonSerializable(typeof(IEnumerable<Currency>))]
    [JsonSerializable(typeof(IEnumerable<FlagSource>))]
    [JsonSerializable(typeof(IEnumerable<Language>))]
    [JsonSerializable(typeof(IEnumerable<RegionalBloc>))]
    [JsonSerializable(typeof(IEnumerable<Translation>))]
    [JsonSourceGenerationOptions(WriteIndented = true)]
    public partial class CountryFlagJsonContext : JsonSerializerContext
    {

    }
}
