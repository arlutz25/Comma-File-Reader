using DataRecordInfo;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var testReader = new DataFileReader();
            testReader.GetRecordsFromDataFile("MyFirstTextFile.txt");
            testReader.GetRecordsFromDataFile("InvalidTestFile.txt");
            testReader.GetRecordsFromDataFile("InvalidFirstName.txt");
            testReader.GetRecordsFromDataFile("InvalidLastName.txt");
            testReader.GetRecordsFromDataFile("InvalidDateOfBirth.txt");
            testReader.GetRecordsFromDataFile("InvalidPlanType.txt");
            testReader.GetRecordsFromDataFile("InvalidEffectiveDate.txt");
        }
    }
}
