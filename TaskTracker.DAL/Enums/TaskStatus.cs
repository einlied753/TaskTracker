using System.Runtime.Serialization;

namespace TaskTracker.DAL.Enums
{
    public enum TaskStatus : byte
    {
        [EnumMember(Value = "toDo")]
        ToDo = 1,

        [EnumMember(Value = "inProgress")]
        InProgress,

        [EnumMember(Value = "done")]
        Done
    }
}

