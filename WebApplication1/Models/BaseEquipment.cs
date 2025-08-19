namespace WebApplication1.Models
{
    public class BaseEquipment
    {
        public int orderID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }

        public List<BaseEquipment> listBase { get; set; }
        public BaseEquipment()
        {
            listBase = new List<BaseEquipment>();
        }

        public static List<BaseEquipment> GetBaseEquipment()
        {
            BaseEquipment baseEquipment = new BaseEquipment();
            List<BaseEquipment> list = new List<BaseEquipment>();

            baseEquipment = new BaseEquipment();
            baseEquipment.orderID = 0;
            baseEquipment.Name = "Base Equipment";
            baseEquipment.Date = DateTime.Now;
            baseEquipment.amount = 1000.00M;
            baseEquipment.status = "Available";
            list.Add(baseEquipment);

            baseEquipment = new BaseEquipment();
            baseEquipment.orderID = 1;
            baseEquipment.Name = "Advanced Equipment";
            baseEquipment.Date = DateTime.Now;
            baseEquipment.amount = 2000.00M;
            baseEquipment.status = "Available";
            list.Add(baseEquipment);

            baseEquipment = new BaseEquipment();
            baseEquipment.orderID = 2;
            baseEquipment.Name = "Premium Equipment";
            baseEquipment.Date = DateTime.Now;
            baseEquipment.amount = 3000.00M;
            baseEquipment.status = "Pending";
            list.Add(baseEquipment);


            baseEquipment = new BaseEquipment();
            baseEquipment.orderID = 3;
            baseEquipment.Name = "Luxury Equipment";
            baseEquipment.Date = DateTime.Now;
            baseEquipment.amount = 5000.00M;
            baseEquipment.status = "Unavailable";
            list.Add(baseEquipment);

            baseEquipment = new BaseEquipment();
            baseEquipment.orderID = 4;
            baseEquipment.Name = "Custom Equipment";
            baseEquipment.Date = DateTime.Now;
            baseEquipment.amount = 10000.00M;
            baseEquipment.status = "Available";
            list.Add(baseEquipment);

            return list;



        }
    }
}
