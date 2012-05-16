using System.Collections.Generic;

namespace prep.collections
{
  public class ProductionStudio
  {
    public static readonly ProductionStudio MGM = new ProductionStudio{Rating = 1};
    public static readonly ProductionStudio Paramount = new ProductionStudio();
    public static readonly ProductionStudio Universal = new ProductionStudio{Rating = 4};
    public static readonly ProductionStudio Pixar = new ProductionStudio{ Rating = 2};
    public static readonly ProductionStudio Disney = new ProductionStudio{Rating = 5};
    public static readonly ProductionStudio Dreamworks = new ProductionStudio{Rating = 3};

      public int Rating { get; set; }


  }

    public class StudioComparer : IComparer<ProductionStudio>  {


        public int Compare( ProductionStudio x, ProductionStudio y ) {
            if (x == null) return 1;
            if (x == y) return 0;
            if (x == ProductionStudio.MGM) return -1;
            if (y == ProductionStudio.MGM) return 1;
            if (x == ProductionStudio.Pixar) return -1;
            if (y == ProductionStudio.Pixar) return 1;
            if (x == ProductionStudio.Dreamworks) return -1;
            if (y == ProductionStudio.Dreamworks) return 1;
            if (x == ProductionStudio.Universal) return -1;
            if (y == ProductionStudio.Universal) return 1;
            if (x == ProductionStudio.Disney) return -1;
            if (y == ProductionStudio.Disney) return 1;
            return 1;
        }
    }
}