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

        ProfessionalOption,

        [Alias("6")]
        ProfessionalCommitment,

        [Alias("11")]
        ProfessionalAppointment,

        [Alias("9")]
        PartnerCommitment,

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