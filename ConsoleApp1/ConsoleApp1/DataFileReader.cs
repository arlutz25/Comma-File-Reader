using System;
using System.Collections.Generic;
using System.IO;

namespace DataRecordInfo
{
    class DataFileReader
    {
        public void GetRecordsFromDataFile(string fileName)
        {
            using (StreamReader DataFile = new StreamReader(fileName))
            {
                string CurrentLine;
                Console.WriteLine("File Read: {0}", fileName);

                while (!DataFile.EndOfStream)
                {
                    CurrentLine = DataFile.ReadLine();
                    List<string> clientRecordFields = new List<string>(CurrentLine.Split(','));
                    ClientRecord currentClientRecord = new ClientRecord(clientRecordFields[0],
                        clientRecordFields[1],
                        clientRecordFields[2],
                        clientRecordFields[3],
                        clientRecordFields[4]);

                    if (!IsClientRecordValid(currentClientRecord))
                    {
                        Console.WriteLine("A record in the file failed validation. Processing has stopped.");
                        break;
                    }

                    string status = currentClientRecord.GetRecordAcceptedOrRejected();

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}",
                        status,
                        currentClientRecord.GetFirstName(),
                        currentClientRecord.GetLastName(),
                        currentClientRecord.GetDOB(),
                        currentClientRecord.GetPlanType(),
                        currentClientRecord.GetEffectiveDate());
                }
            }
        }

        bool IsClientRecordValid(ClientRecord record)
        {
            bool firstNameValid = !string.IsNullOrEmpty(record.GetFirstName());
            bool lastNameValid = !string.IsNullOrEmpty(record.GetLastName());
            string planType = record.GetPlanType();
            bool planTypeValid = planType == "HSA"
                || planType == "HRA"
                || planType == "FSA";

            return firstNameValid 
                && lastNameValid 
                && record.IsDOBValid() 
                && planTypeValid 
                && record.IsEffectiveDateValid();
        }
    }
}
