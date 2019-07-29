using Catharsium.Util.Attributes;

namespace Catharsium.Calendar.Core.Entities.Models.Enums
{
    public enum Category
    {
        [Alias("1")]
        PersonalOption,

        [Alias("7")]
        PersonalCommitment,

        [Alias("9")]
        PersonalAppointment,

        [Alias("4")] //2
        ProfessionalOption,

        [Alias("6")]
        ProfessionalCommitment,

        [Alias("11")]
        ProfessionalAppointment,

        [Alias("3")]
        PartnerCommitment,

        [Alias("5")]
        Birthday,

        Meal,

        Special,

        [Alias("10")]
        Free,

        [Alias("8")]
        Traveling,

        Unknown
    }
}