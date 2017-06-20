using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace CMSUsersAndRoles.Models
{
    public enum UnitOfMeasure
    {
        oz=1,
        lb=2,
        ml=3,
        liter=4,
        gal=5
    }
    public class Ingredient: IEnumerator, IEnumerable
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public Formula Formula { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        [Column(Order = 2)]
        public int IngredientId { get; set; }
        [Required, MaxLength(50), Display(Name = "Ingredient")]
        public string Name { get; set; }
        [Range(.00001, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage="Please make a selection")]
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        private List<Ingredient> ingredients = new List<Ingredient>();
        int position = -1;

        public object Current
        {
           
            get
            {
                //var ingredients = new List<Ingredient>();
                return ingredients[-1]; 
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < ingredients.Count);
        }

        public void Reset()
        {
            { position = 0; }
        }

        public IEnumerator GetEnumerator()
        {
            var ingredients = new List<Ingredient>() { new Ingredient { Name = "new Item", Amount = 1 } };
            //var ingredients = new List<Ingredient>() { new Ingredient {IngredientId = this.IngredientId, ProductId=this.ProductId,
            //Name = "new Item", Amount = 1, UnitOfMeasure = UnitOfMeasure.ml } };

            return ((IEnumerable)ingredients).GetEnumerator();
        }
    }
}