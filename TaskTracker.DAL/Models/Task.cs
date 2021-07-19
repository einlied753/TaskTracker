using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTracker.DAL.Enums;

namespace TaskTracker.DAL.Models
{
    public class Task : BaseEntity
    {
        /// <summary>
        /// Task name
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Number of project to which task belongs
        /// </summary>
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        [MaxLength(8000)]
        public string Description { get; set; }

        /// <summary>
        /// Task Status
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Task Priority
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Task Role
        /// </summary>
        public TaskRole Role { get; set; }

        /// <summary>
        /// User to whom the task was assigned
        /// </summary>
        public int? AssigneeId { get; set; }

        [ForeignKey("AssigneeId")]
        public virtual User Assignee { get; set; }

        /// <summary>
        /// User who created the task
        /// </summary>
        public int? ReporterId { get; set; }

        [ForeignKey("ReporterId")]
        public virtual User Reporter { get; set; }

        /// <summary>
        /// Analyst of task
        /// </summary>
        public int? AnalystId { get; set; }

        [ForeignKey("AnalystId")]
        public virtual User Analyst { get; set; }

        /// <summary>
        /// Developer of task
        /// </summary>
        public int? DeveloperId { get; set; }

        [ForeignKey("DeveloperId")]
        public virtual User Developer { get; set; }

        /// <summary>
        /// Tester of task
        /// </summary>
        public int? TesterId { get; set; }

        [ForeignKey("TesterId")]
        public virtual User Tester { get; set; }

        /// <summary>
        /// Created date of task
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
