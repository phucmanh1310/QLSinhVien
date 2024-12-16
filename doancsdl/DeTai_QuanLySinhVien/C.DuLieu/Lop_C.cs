using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;
using System;

namespace C.DuLieu
{
    public class Lop_C
    {
        private IMongoCollection<BsonDocument> collection;

        public Lop_C()
        {
            // Kết nối MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối tới collection "Lop"
            collection = database.GetCollection<BsonDocument>("Lop");
        }

        // Lấy danh sách lớp học
        public List<BsonDocument> DanhSachLop()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Lấy danh sách thông tin đầy đủ lớp học
        public List<BsonDocument> DanhSach_ThongTin_Lop()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Thêm lớp học mới
        public void ThemLopHocMoi(Lop_ThongTin Lop)
        {
            // Kiểm tra trùng mã lớp học
            var existingLop = collection.Find(Builders<BsonDocument>.Filter.Eq("MaLop", Lop.MaLop)).FirstOrDefault();
            if (existingLop != null)
            {
                throw new Exception($"Mã lớp {Lop.MaLop} đã tồn tại!");
            }

            var document = new BsonDocument
            {
                { "MaLop", Lop.MaLop },
                { "TenLop", Lop.TenLop },
                { "MaKhoaHoc", Lop.MaKhoaHoc },
                { "MaHeDaoTao", Lop.MaHeDaoTao },
                { "MaNganh", Lop.MaNganh }
            };

            collection.InsertOne(document);
        }


        // Sửa thông tin lớp học
        public void SuaThongTinLopHoc(Lop_ThongTin Lop)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaLop", Lop.MaLop);
            var update = Builders<BsonDocument>.Update
                .Set("TenLop", Lop.TenLop)
                .Set("MaKhoaHoc", Lop.MaKhoaHoc)
                .Set("MaHeDaoTao", Lop.MaHeDaoTao)
                .Set("MaNganh", Lop.MaNganh);

            var result = collection.UpdateOne(filter, update);
            if (result.MatchedCount == 0)
            {
                throw new Exception("Không tìm thấy lớp học cần chỉnh sửa.");
            }
        }


        // Xóa lớp học
        public void XoaLopHoc(Lop_ThongTin Lop)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaLop", Lop.MaLop);

            // Kiểm tra dữ liệu liên quan trong BangDiem
            var bangDiemCollection = collection.Database.GetCollection<BsonDocument>("BangDiem");
            var relatedData = bangDiemCollection.Find(Builders<BsonDocument>.Filter.Eq("MaLop", Lop.MaLop)).FirstOrDefault();

            if (relatedData != null)
            {
                throw new Exception($"Không thể xóa lớp học {Lop.MaLop} vì có dữ liệu liên quan trong bảng Điểm.");
            }

            // Thực hiện xóa nếu không có dữ liệu liên quan
            var result = collection.DeleteOne(filter);
            if (result.DeletedCount == 0)
            {
                throw new Exception("Không tìm thấy lớp học để xóa.");
            }
        }
        public List<BsonDocument> DanhSach_ThongTin_DayDu()
        {
            var pipeline = new[]
            {
        new BsonDocument("$lookup", new BsonDocument
        {
            { "from", "HeDaoTao" },
            { "localField", "MaHeDaoTao" },
            { "foreignField", "MaHe" },
            { "as", "HeDaoTao_Info" }
        }),
        new BsonDocument("$lookup", new BsonDocument
        {
            { "from", "NganhDaoTao" },
            { "localField", "MaNganh" },
            { "foreignField", "MaNganh" },
            { "as", "NganhDaoTao_Info" }
        }),
        new BsonDocument("$lookup", new BsonDocument
        {
            { "from", "Khoa" },
            { "localField", "MaKhoa" },
            { "foreignField", "MaKhoa" },
            { "as", "Khoa_Info" }
        }),
        new BsonDocument("$project", new BsonDocument
        {
            { "MaLop", 1 },
            { "TenLop", 1 },
            { "MaKhoaHoc", 1 },
            { "TenHe", new BsonDocument("$arrayElemAt", new BsonArray { "$HeDaoTao_Info.TenHe", 0 }) },
            { "TenNganh", new BsonDocument("$arrayElemAt", new BsonArray { "$NganhDaoTao_Info.TenNganh", 0 }) },
            { "TenKhoa", new BsonDocument("$arrayElemAt", new BsonArray { "$Khoa_Info.TenKhoa", 0 }) }
        })
    };

            return collection.Aggregate<BsonDocument>(pipeline).ToList();
        }




        // Tìm kiếm lớp học
        public List<BsonDocument> TimKiemLopHoc(Lop_ThongTin Lop)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaLop", new BsonRegularExpression(Lop.MaLop, "i"));
            return collection.Find(filter).ToList();
        }
    }
}
