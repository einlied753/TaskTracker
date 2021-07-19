using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DAL.Models
{
    public class User : BaseEntity
    {
        /// <summary>
        /// User name
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// User surname
        /// </summary>
        [MaxLength(50)]
        public string Surname { get; set; }

        /// <summary>
        /// User patronymic
        /// </summary>
        [MaxLength(50)]
        public string Patronymic { get; set; }

        /// <summary>
        /// User position
        /// </summary>
        [MaxLength(100)]
        public string Position { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
    }
}
