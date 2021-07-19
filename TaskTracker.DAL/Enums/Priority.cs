using System.Runtime.Serialization;

namespace TaskTracker.DAL.Enums
{
    public enum Priority
    {
        [EnumMember(Value = "low")]
        Low = 1,

        [EnumMember(Value = "medium")]
        Medium,

        [EnumMember(Value = "high")]
        High,

        [EnumMember(Value = "highest")]
        Highest
    }
}

