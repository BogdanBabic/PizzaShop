namespace PizzaShop.Models
{
    public class PieRepository : IPieRepository
    {
        public List<Pie> AllPies 
        {
           get { return allPies; }
           set { allPies = value; }
        }
        public Pie GetPieById(int pieId)
        {
            foreach (var Pie in allPies) 
            {
                if(Pie.PieID == pieId)
                    return Pie;
            }

            return null;
        }
        private List<Pie> allPies = new List<Pie>();
        private List<Category> Categories = new List<Category>();
        public PieRepository()
        {
            Category category1 = new Category();
            category1.CategoryID = 1;
            category1.Name = "Pice sa mesom";
            category1.Description = "Description";

            Category category2 = new Category();
            category2.CategoryID = 2;
            category2.Name = "Veganske pice";
            category2.Description = "Description";

            Category category3 = new Category();
            category3.CategoryID = 3;
            category3.Name = "Pice bez glutena";
            category3.Description = "Description";

            Pie p1 = new Pie();
            p1.PieID = 1;
            p1.Name = "Pita s jabukama";
            p1.Description = "Mala pita sa jabukama";
            p1.Price = 1.25;
            p1.IsPieOfTheWeek = true;
            p1.InStock = true;
            p1.Category = category2;

            Pie p2 = new Pie();
            p2.PieID = 2;
            p2.Name = "Makovnjaca";
            p2.Description = "Velika strudla s makom";
            p2.Price = 8.35;
            p2.IsPieOfTheWeek = false;
            p2.InStock = false;
            p2.Category = category2;

            Pie p3 = new Pie();
            p3.PieID = 3;
            p3.Name = "Burek";
            p3.Description = "Masan burek sa sirom";
            p3.Price = 6.5;
            p3.IsPieOfTheWeek = false;
            p3.InStock = true;
            p3.Category = category3;

            Pie p4 = new Pie();
            p4.PieID = 4;
            p4.Name = "Pita sa krompirom";
            p4.Description = "Velika pita sa krompirom";
            p4.Price = 1;
            p4.IsPieOfTheWeek = false;
            p4.InStock = true;
            p4.Category = category2;

            Pie p5 = new Pie();
            p5.PieID = 5;
            p5.Name = "Prazna bezglutenska pita";
            p5.Description = "Pita od bezglutenskog brasna";
            p5.Price = 5.5;
            p5.IsPieOfTheWeek = false;
            p5.InStock = false;
            p5.Category = category3;

            Pie p6 = new Pie();
            p6.PieID = 6;
            p6.Name = "Pita sa bundevama";
            p6.Description = "Mala pita sa bundevama";
            p6.Price = 3.5;
            p6.IsPieOfTheWeek = false;
            p6.InStock = true;
            p6.Category = category2;

            Pie p7 = new Pie();
            p7.PieID = 7;
            p7.Name = "Burek sa kolenicom";
            p7.Description = "Masan burek sa kolenicom";
            p7.Price = 7;
            p7.IsPieOfTheWeek = false;
            p7.InStock = true;
            p7.Category = category1;

            Pie p8 = new Pie();
            p8.PieID = 8;
            p8.Name = "Pita pizza";
            p8.Description = "Pita sa sunkom, kecapom i sirom";
            p8.Price = 7.5;
            p8.IsPieOfTheWeek = false;
            p8.InStock = true;
            p8.Category = category1;

            Pie p9 = new Pie();
            p9.PieID = 9;
            p9.Name = "Pita sa pecurkama";
            p9.Description = "Pita sa vrganjima i sampinjonima";
            p9.Price = 4.4;
            p9.IsPieOfTheWeek = false;
            p9.InStock = false;
            p9.Category = category2;

            Pie p10 = new Pie();
            p10.PieID = 10;
            p10.Name = "Burek sa mesom";
            p10.Description = "Klasican burek sa mesom i lukom";
            p10.Price = 5;
            p10.IsPieOfTheWeek = false;
            p10.InStock = false;
            p10.Category = category1;

            allPies.Add(p1);
            allPies.Add(p2);
            allPies.Add(p3);
            allPies.Add(p4);
            allPies.Add(p5);
            allPies.Add(p6);
            allPies.Add(p7);
            allPies.Add(p8);
            allPies.Add(p9);
            allPies.Add(p10);
        }
    }
}
