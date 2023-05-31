using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProductReviewProblemStatement
{
    public class Management
    {
        public void TopRecords(List<ProductReview> productReviewList)
        {
            // var result = this.productReviews.OrderByDescending(x => x.Rating).Take(3);
            var recordedData = (from productReviews in productReviewList
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            // var result = this.productReviews.Where(x => x.Rating > 3 && (x.ProductId == 1 || x.ProductId == 3 || x.ProductId == 9));
            var recordedData = (from productReviews in listProductReview
                                where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                && productReviews.Rating > 3
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            //var result = this.productReviews.GroupBy(x => x.ProductId);
            //foreach (var data in result)
            //{
            //    Console.WriteLine("No Of Reviews For ProductId {0}:{1}", data.Key, data.Count());
            //    PrintList(data.ToList());
            //}
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + "------" + list.Count);
            }
        }
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               select new
                               {
                                   productReviews.ProductId,
                                   productReviews.Review
                               };
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product Id:- " + list.ProductId + " " + "Review: " + list.Review);
            }
        }
        public void RetrieveProductsBySkippingTop5(List<ProductReview> listProductReview)
        {
            //var result = this.productReviews.Select(x => new { x.ProductId, x.Rating });
            //foreach (var data in result)
            //{
            //    Console.WriteLine("ProductId:" + data.ProductId + " " + "Rating:" + data.Rating);
            //}
            //var result = this.productReviews.OrderByDescending(x => x.Rating).Skip(5);
            var recordedData = (from productReviews in listProductReview
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        public DataTable AddToDataTable(List<ProductReview> listProductReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("UserId", typeof(int));
            table.Columns.Add("Rating", typeof(double));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("IsLike", typeof(bool));
            foreach (ProductReview product in listProductReviews)
            {
                table.Rows.Add(product.ProductId, product.UserId, product.Rating, product.Review, product.IsLike);
            }
            return table;
        }
    }
}
