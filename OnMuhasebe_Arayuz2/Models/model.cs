namespace OnMuhasebe_Arayuz2.Models
{
    public class IncomeRecord
    {
        public int id { get; set; }
        public string ad { get; set; }
        public int miktar { get; set; }
        public int deger { get; set; }
        public DateTime tarih { get; set; }
    }
    public class ExpenseRecord
    {
        public int id { get; set; }
        public string ad { get; set; }
        public int miktar { get; set; }
        public int deger { get; set; }
        public DateTime tarih { get; set; }       
    }
    public class TotalRecord
    {
        public int id { get; set; }
        public DateTime SorguTarihi { get; set; }
        public int ToplamGelir { get; set; }
        public int ToplamGider { get; set; }
        public int Net { get; set; }
    }
    public class Date
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
   
}
