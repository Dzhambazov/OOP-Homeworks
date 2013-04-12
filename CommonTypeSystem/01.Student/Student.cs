using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
    enum University
    {
        NBU, SU, TU, UNSS
    }

    enum Faculty
    {
        IT, Medicine, Art
    }

    enum Specialty
    {
        Developer, Surgeon, Artist
    }

    class Student : ICloneable, IComparable<Student>
    {
        //first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public byte Course { get; set; }
        public University Uni { get; set; }
        public Faculty Fac { get; set; }
        public Specialty Spec { get; set; }

        public Student(string firstName, string middleName, string lastName, string ssn, string address, string mobile, string email,
                        byte course, University uni, Faculty fac, Specialty spec)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.Mobile = mobile;
            this.Email = email;
            this.Course = course;
            this.Uni = uni;
            this.Fac = fac;
            this.Spec = spec;
        }

        public override bool Equals(object obj)
        {
            if (((obj as Student).SSN) != this.SSN)
                return false;

            return true;
        }

        public static bool operator ==(Student studen1, Student student2)
        {
            return(studen1.SSN == student2.SSN);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return(student1.SSN != student2.SSN);
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.SSN.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("SSN: " + this.SSN);
            result.AppendLine("Name: " + this.FirstName + this.MiddleName + this.LastName);
            result.AppendLine("Address: " + this.Address);
            result.AppendLine("Mobile: " + this.Mobile);
            result.AppendLine("Email: " + this.Email);
            result.AppendLine("Course: " + this.Course);
            result.AppendLine("University: " + this.Uni);
            result.AppendLine("Faculty: " + this.Fac);
            result.AppendLine("Specialty: " + this.Spec);
            return result.ToString();
        }

        public Student Clone()
        {
            return new Student(this.FirstName,this.MiddleName,this.LastName,this.SSN,this.Address,this.Mobile,
                               this.Email, this.Course, this.Uni, this.Fac, this.Spec);
        }

        Object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student otherStudent)
        {
            if (this.FirstName != otherStudent.FirstName)
            {
                return (this.FirstName.CompareTo(otherStudent.FirstName));
            }
            else if (this.MiddleName != otherStudent.MiddleName)
            {
                return (this.MiddleName.CompareTo(otherStudent.MiddleName));
            }
            else if (this.LastName != otherStudent.LastName)
            {
                return (this.LastName.CompareTo(otherStudent.LastName));
            }
            else
            {
                return (this.SSN.CompareTo(otherStudent.SSN));
            }

        }
        public static void Main()
        {

        }
    }