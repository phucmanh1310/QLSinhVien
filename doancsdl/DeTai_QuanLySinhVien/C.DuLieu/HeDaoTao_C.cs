using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;
using System;
using System.Linq;
using System.Data;

namespace C.DuLieu
{
    public class HeDaoTao_C
    {
        private IMongoCollection<BsonDocument> collection;

        public HeDaoTao_C()
        {
            try
            {
                // Kết nối MongoDB
                var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
                var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                collection = database.GetCollection<BsonDocument>("HeDaoTao");
            }
            catch (Exception ex)
            {
               Console.WriteLine("Lỗi kết nối MongoDB: " + ex.Message);
            }
        }


        // Lấy danh sách hệ đào tạo
        public DataTable DanhSachHeDaoTao()
        {
            var filter = new BsonDocument();
            var documents = collection.Find(filter).ToList();
            return DataConversion1.ConvertToDataTable1(documents); // Làm sạch dữ liệu
        }


        // Xóa 1 hệ đào tạo
        public void XoaHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHe", HDT.MaHe);
            collection.DeleteOne(filter);
        }

        // Thêm 1 hệ đào tạo
        public void ThemHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            var document = new BsonDocument
            {
                { "MaHe", HDT.MaHe },
                { "TenHe", HDT.TenHe }
            };
            collection.InsertOne(document);
        }

        // Sửa 1 hệ đào tạo
        public void SuaHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHe", HDT.MaHe);
            var update = Builders<BsonDocument>.Update.Set("TenHe", HDT.TenHe);
            collection.UpdateOne(filter, update);
        }

        // Tìm kiếm hệ đào tạo
        public List<BsonDocument> TimKiemHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaHe", new BsonRegularExpression(HDT.MaHe, "i"));
            var documents = collection.Find(filter).ToList();
            return SanitizeBsonDocuments(documents); // Làm sạch dữ liệu
        }
        // Hàm chuyển đổi BsonDocument thành dữ liệu an toàn
        private List<BsonDocument> SanitizeBsonDocuments(List<BsonDocument> documents)
        {
            foreach (var doc in documents)
            {
                foreach (var element in doc.Elements.ToList())
                {
                    if (element.Value.IsBsonDocument || element.Value.IsBsonArray)
                    {
                        doc[element.Name] = element.Value.ToString(); // Chuyển thành chuỗi JSON
                    }
                }
            }
            return documents;
        }
    }
}
