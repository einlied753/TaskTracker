using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DAL.Models
{
    public class Project : BaseEntity
    {
        //public Project()
        //{
        //    Tasks = new HashSet<Task>();
        //}

        /// <summary>
        /// Project name
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Project start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Project completition date
        /// </summary>
        public DateTime CompletitionDate { get; set; }

        /// <summary>
        /// Project status
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Project priority
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Project created date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Project set of tasks
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
