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
                        currentClientRecord.FirstName,
                        currentClientRecord.LastName,
                        currentClientRecord.DateOfBirth.ToShortDateString(),
                        currentClientRecord.PlanType,
                        currentClientRecord.EffectiveDate.ToShortDateString());
                }
            }
        }

        bool IsClientRecordValid(ClientRecord record)
        {
            bool firstNameValid = !string.IsNullOrEmpty(record.FirstName);
            bool lastNameValid = !string.IsNullOrEmpty(record.LastName);
            bool planTypeValid = record.PlanType == "HSA"
                || record.PlanType == "HRA"
                || record.PlanType == "FSA";

            return firstNameValid && lastNameValid && record.DOBValid && planTypeValid && record.EffectiveDateValid;
        }
    }
}
