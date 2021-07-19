using System.Runtime.Serialization;

namespace TaskTracker.DAL.Enums
{
    public enum ProjectStatus : byte
    {
        [EnumMember(Value = "notStarted")]
        NotStarted = 1,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "completed")]
        Completed
    }
}
