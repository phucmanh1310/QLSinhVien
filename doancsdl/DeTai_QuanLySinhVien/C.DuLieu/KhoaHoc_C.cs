using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;
using System;

namespace C.DuLieu
{
    public class KhoaHoc_C
    {
        private IMongoCollection<BsonDocument> collection;

        public KhoaHoc_C()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            collection = database.GetCollection<BsonDocument>("KhoaHoc");
        }

        public List<BsonDocument> DanhSachKhoaHoc()
        {
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }

        public List<BsonDocument> DanhSach_ThongTin_KhoaHoc()
        {
            var documents = collection.Find(new BsonDocument()).ToList();
            return documents;
        }

        public void ThemKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var document = new BsonDocument
            {
                { "MaKhoaHoc", KH.MaKhoaHoc },
                { "NgayBatDau", KH.NgayBatDau },
                { "NgayKetThuc", KH.NgayKetThuc }
            };
            collection.InsertOne(document);
        }

        public void ChinhSuaKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaKhoaHoc", KH.MaKhoaHoc);
            var update = Builders<BsonDocument>.Update
                .Set("NgayBatDau", KH.NgayBatDau)
                .Set("NgayKetThuc", KH.NgayKetThuc);
            collection.UpdateOne(filter, update);
        }

        public void XoaKhoaHoc(KhoaHoc_ThongTin KH)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaKhoaHoc", KH.MaKhoaHoc);
                var result = collection.DeleteOne(filter);

                if (result.DeletedCount == 0)
                {
                    throw new Exception($"Không tìm thấy khóa học có mã {KH.MaKhoaHoc}.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khóa học: " + ex.Message);
            }
        }


        public List<BsonDocument> TimKiemKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaKhoaHoc", new BsonRegularExpression(KH.MaKhoaHoc, "i"));
            return collection.Find(filter).ToList();
        }
    }
}
