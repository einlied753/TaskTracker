using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Enums
{
    public enum TaskRole : byte
    {
        [EnumMember(Value = "epic")]
        Epic = 1,

        [EnumMember(Value = "story")]
        Story,

        [EnumMember(Value = "task")]
        Task,

        [EnumMember(Value = "bug")]
        Bug,

        [EnumMember(Value = "improvement")]
        Improvement,

        [EnumMember(Value = "newFeature")]
        NewFeature,

        [EnumMember(Value = "subTask")]
        SubTask
    }
}
