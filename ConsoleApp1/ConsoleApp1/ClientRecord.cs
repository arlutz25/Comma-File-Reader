using System;

namespace DataRecordInfo
{
    public class ClientRecord
    {
        public ClientRecord(string firstName, string lastName, string dateOfBirth, string planType, string effectiveDate)
        {
            FirstName = firstName;
            LastName = lastName;
            DOBValid = DateTime.TryParseExact(dateOfBirth, "MMddyyyy",
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateOfBirth);
            PlanType = planType;
            EffectiveDateValid = DateTime.TryParseExact(effectiveDate, "MMddyyyy",
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out EffectiveDate);
        }

        public string GetRecordAcceptedOrRejected()
        {
            return (DateTime.Compare(DateTime.Today.AddDays(30), EffectiveDate) < 0
                || DateTime.Compare(DateTime.Today, DateOfBirth.AddYears(18)) < 0) ? "Rejected" : "Accepted";
        }

        public string GetFirstName()            { return FirstName; }
        public string GetLastName()             { return LastName; }
        public string GetDOB()                  { return DateOfBirth.ToShortDateString(); }
        public string GetPlanType()             { return PlanType; }
        public string GetEffectiveDate()        { return EffectiveDate.ToShortDateString(); }
        public bool   IsDOBValid()              { return DOBValid; }
        public bool   IsEffectiveDateValid()    { return EffectiveDateValid; }

        private string FirstName;
        private string LastName;
        private DateTime DateOfBirth;
        private string PlanType;
        private DateTime EffectiveDate;

        private bool DOBValid;
        private bool EffectiveDateValid;
    }
}
