using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ActionSale {

    public int Id { get; set; }
    public double Discount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
