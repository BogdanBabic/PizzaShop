namespace PizzaShop.Models
{
    public class PieRepository : IPieRepository
    {
        public List<Pie> AllPies 
        {
           get { return privatePies; }
        }
        public Pie GetPieById(int pieId)
        {
            foreach (var Pie in privatePies) 
            {
                if(Pie.PieID == pieId) return Pie;
            }

            return null;
        }
        private List<Pie> privatePies = new List<Pie>();
        public PieRepository()
        {
            Pie p1 = new Pie();
            p1.PieID = 1;
            p1.Name = "Pita s jabukama";
            p1.Description = "Mala pita sa jabukama";
            p1.Price = 1.25;

            Pie p2 = new Pie();
            p2.PieID = 2;
            p2.Name = "Makovnjaca";
            p2.Description = "Velika strudla s makom";
            p2.Price = 8.35;

            Pie p3 = new Pie();
            p3.PieID = 3;
            p3.Name = "Burek";
            p3.Description = "Masan burek sa sirom";
            p3.Price = 6.5;

            privatePies.Add(p1);
            privatePies.Add(p2);
            privatePies.Add(p3);


        }
    }
}
