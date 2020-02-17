using SlavaQuest.TipoTam;

namespace SlavaQuest.TipoTam2
{

    public class Staff : IDutyForLowRanks
    {
        public void LowRanks()
        {
            int a;
        }
    }

    public class Admins : IDutyForHighRanks
    {
        public void HighRanks()
        {
            var obj = new Staff();
            obj.LowRanks();
            obj.ToString();
        }
    }

    public static class Example
    {
        static Example()
        {
            GetListOfDuty(new Admins(), new Staff());
        }

        public static void GetListOfDuty(IDutyForHighRanks listForHighRanks, IDutyForLowRanks listForLowRanks)
        {
            listForLowRanks.LowRanks();
            listForHighRanks.HighRanks();
        }
    }
}
