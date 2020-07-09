using System;
using System.Collections.Generic;



namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.
        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, EmployerName, EmployerLocation, JobType, JobCoreCompetency);
        }

        
        
        public override string ToString()
        {
            List<string> list = new List<string>{ Name, EmployerName.ToString(), EmployerLocation.ToString(), JobType.ToString(), JobCoreCompetency.ToString() };
            for(int i=0; i<list.Count; i++)
            {
                if(list[i] == "")
                {
                    list[i] = "Data not available";
                }
            }
            if (list[0] == "Data not available" &&
                list[1] == "Data not available" &&
                list[2] == "Data not available" &&
                list[3] == "Data not available" &&
                list[4] == "Data not available")
            {
                return "OOPS! This job does not seem to exist.";
            }
            else
            {
                return "" + "\n"
                    + "ID: " + Convert.ToString(Id) + "\n"
                    + "Name: " + list[0] + "\n"
                    + "Employer: " + list[1] + "\n"
                    + "Location: " + list[2] + "\n"
                    + "Position Type: " + list[3] + "\n"
                    + "Core Competency: " + list[4] + "\n"
                    + "";
            }
        }
    }
}