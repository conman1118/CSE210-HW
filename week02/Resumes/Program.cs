using System;


class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Property Manager";
        job1._company = "Pink Door Storage";
        job1._startYear = 2024;
        job1._endYear = 2025;
        job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Fry's";
        job2._startYear = 2021;
        job2._endYear = 2022;
        job2.Display();


        Resume resume = new Resume();
        resume._name = "Connor Neus";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}