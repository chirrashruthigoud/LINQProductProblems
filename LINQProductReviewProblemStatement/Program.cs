using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProductReviewProblemStatement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management");
            //Product Review List
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview() { ProductId = 1, UserId = 1, Rating = 2, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 2, UserId = 1, Rating = 4, Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 3, UserId = 2, Rating = 5, Review = "Good",IsLike = false },
                new ProductReview() { ProductId = 4, UserId = 3, Rating = 6, Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 5, UserId = 1, Rating = 2, Review = "nice", IsLike = true },
                new ProductReview() { ProductId = 6, UserId = 6, Rating = 1, Review = "bad", IsLike = true },
                new ProductReview() { ProductId = 7, UserId = 4, Rating = 1, Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 8, UserId = 8, Rating =5,Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 9, UserId = 2, Rating =6,Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 10, UserId = 5, Rating =2,Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 11, UserId = 8, Rating =9,Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 12, UserId = 4, Rating =3,Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 13, UserId = 6, Rating =8,Review = "Good", IsLike = true },
                new ProductReview() { ProductId = 14, UserId = 9, Rating =9,Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 15, UserId = 8, Rating =2,Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 16, UserId = 5, Rating =9,Review = "Good", IsLike = false },
                new ProductReview() { ProductId = 17, UserId = 3, Rating =2,Review = "Good", IsLike = true },
            };

            Console.WriteLine("choose one option");
            Management management = new Management();
            Console.WriteLine("1.For each \n2. top records \n3.SelectRecords \n4.RetrieveCountOfRecords \n5.RetrieveProductIdAndReview \n6.RetrieveProductsBySkippingTop5 \n7.DataTable");
            int option =Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    foreach (var list in productReviewList)
                    {
                        Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                            + "Review: " + list.Review + "IsLike: " + list.IsLike);
                    }
                    break;

                case 2:
                    //Getting Top 3 rated records
                    management.TopRecords(productReviewList);
                    break;
                case 3:
                    management.SelectRecords(productReviewList);
                    break;
                case 4:
                    management.RetrieveCountOfRecords(productReviewList);
                    break;

                    case 5:
                    management.RetrieveProductIdAndReview(productReviewList);
                    break;

                case 6:
                    management.RetrieveProductsBySkippingTop5(productReviewList);
                    break;
                case 7:
                    DataTable dataTable =management.AddToDataTable(productReviewList);
                    break;
            }

            Console.ReadLine();
        }
    }
}
