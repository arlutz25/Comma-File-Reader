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

        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        public string PlanType;
        public DateTime EffectiveDate;

        public bool DOBValid;
        public bool EffectiveDateValid;
    }
}
