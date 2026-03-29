using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    internal class Member
    {
        private string memberID, firstName, lastName, gender, phoneNumber, address, trainingProgram;
        private DateTime dob, start, end;

        public Member(string memberID, string firstName, string lastName, string gender, string phoneNumber, string address, string trainingProgram, DateTime dob, DateTime start, DateTime end)
        {
            this.memberID = memberID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.trainingProgram = trainingProgram;
            this.dob = dob;
            this.start = start;
            this.end = end;
        }

        public string MemberID { get => memberID; set => memberID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public string TrainingProgram { get => trainingProgram; set => trainingProgram = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
    }
}
