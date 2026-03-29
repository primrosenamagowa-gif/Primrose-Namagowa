using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    internal class TrainingProgram
    {
        private string classId, capacity;
        private string className, description, instructor, schedule, duration;

        public TrainingProgram(string classId, string capacity, string className, string description, string instructor, string schedule, string duration)
        {
            this.classId = classId;
            this.capacity = capacity;
            this.className = className;
            this.description = description;
            this.instructor = instructor;
            this.schedule = schedule;
            this.duration = duration;
        }

        public string ClassId { get => classId; set => classId = value; }
        public string Capacity { get => capacity; set => capacity = value; }
        public string ClassName { get => className; set => className = value; }
        public string Description { get => description; set => description = value; }
        public string Instructor { get => instructor; set => instructor = value; }
        public string Schedule { get => schedule; set => schedule = value; }
        public string Duration { get => duration; set => duration = value; }
    }
}
